using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour 
{

	public enum GeneratorType
	{
		normal,
		degree,
		perlin,
		simple,
		superFlat
	}

	public GeneratorType generatorType = GeneratorType.perlin;

	// Cube prefab
	public Transform groundCube;
	// Water prefab
	public Transform waterPlane;
	// Gut prefab
	public Transform gut;
	// Terrain object from scene
	public GameObject terrain;

	// World length in cubes (x-axis)
	public int length = 30;
	// World width in cubes (z-axis)
	public int width = 30; 
	// Min Y coord in cubeparts
	public int minHeight = 0;
	// Max Y coord in cubeparts
	public int maxHeight = 150;
	// Cube height in cubeparts
	public int cubeHeigth = 3;
	// Max height shift in cubeparts
	public int localDelta = 15;
	// Degree random degree
	public float degreeDistDegree = 400f;
	// Random seed
	public int seed = 5324;
	// Sigma parameter in normal distribution random 
	public float normalDistSigma = 0.02f;
	// Perlin scale
	public float perlinScale = 4f;
	// (1.0 Terrain height) / (1.0 Y height)
	public float terrainHeightScale = 0.00167f;

	int[,] heights;
	private int i;
	private int j;

	// Use this for initialization
	void Start () 
	{
		Random.seed = seed;
		Terrain trn = terrain.GetComponent<Terrain>();
		TerrainData td = trn.terrainData;
		//length = td.heightmapWidth;
		//width = td.heightmapHeight;
		float[,] hm = new float[length, width];
		heights = new int[length, width];

		int max = minHeight;
		int min = maxHeight;
		int maxX = 0;
		int maxY = 0;




        for (i = 0; i < width; ++i) {
		    for (j = 0; j < length; ++j) 
		    {
				int height = 0;
				if(generatorType != GeneratorType.perlin)
				{
					if(i == 0)
					{
					    if(j == 0)
						{
							height = randInRange(minHeight, maxHeight, GeneratorType.simple);
						}
						else
						{
							int prevH = heights[i,j-1];
							height = prevH + randInRange(-localDelta, localDelta);
							height = Mathf.Clamp(height, minHeight,maxHeight);
					    }
					}
					else
					{
						if(j == 0)
						{
							int prevH = heights[i-1,j];
							height = prevH + randInRange(-localDelta, localDelta);
							height = Mathf.Clamp(height, minHeight,maxHeight);
						}
						else
						{
							int a = heights[i,j-1];
							int a1 = a - localDelta;
							int a2 = a + localDelta;
							int b = heights[i-1,j];
							int b1 = b - localDelta;
							int b2 = b + localDelta;

							int left = System.Math.Max(a1, b1);
							int right = System.Math.Min(a2, b2);

							//int left = System.Math.Min(a1, b1);
							//int right = System.Math.Max(a2, b2);

							if(left <= right)
							{
								height = randInRange(left, right);
								height = Mathf.Clamp(height, minHeight,maxHeight);
							}
							else
							{
								height = (heights[i,j-1] + heights[i-1,j] + 
								          2*randInRange(-localDelta, localDelta))/2;
								height = System.Math.Max(height, minHeight);
								height = System.Math.Min(height, maxHeight);
								Debug.Log("bad range");
							}
						}
					}
				}
				else
				{
					height = randInRange(minHeight, maxHeight);
				}

				if(height > max)
				{
					max = height;
					maxX = i;
					maxY = j;
				}
				if(height < min)
				{
					min = height;
				}

				heights[i,j] = height; 
				hm[i,j] = toY(height)*terrainHeightScale;

				Transform grc 
					= (Transform)Instantiate(
						groundCube, 
			            new Vector3(
							toX (j),
							toY (height)/2f,
							toZ (i)), 
               			Quaternion.identity);

				grc.localScale = new Vector3(
					grc.localScale.x 
					,toY (height), 
					grc.localScale.z);
				 
				GroundClick cmpt = grc.GetComponent<GroundClick>();
				cmpt.i = i;
				cmpt.j = j;
			}


		}
		td.SetHeights(0, 0, hm);

		int height0 = (max+min)/2;
		Instantiate(
			waterPlane, 
            new Vector3(
				toX(length/2),
				toY(height0),
				toZ(width/2)), 
            Quaternion.identity);
	}

	float toX(int j)
	{
		return j * groundCube.transform.localScale.x;
	}

	float toY(int height)
	{
		return (float)height * (groundCube.transform.localScale.y / (float)cubeHeigth);
	}

	float toZ(int i)
	{
		return i*groundCube.transform.localScale.z;
	}

	int randInRange(int a, int b, GeneratorType generatorType)
	{
		
		
		float val = 0;
		switch(generatorType)
		{
		case GeneratorType.degree:
			val = randInRangeDegree ();
			break;
		case GeneratorType.normal:
			val = randInRangeNormal ();
			break;
		case GeneratorType.perlin:
			perlinNoise ();
			break;
		}
		
		return (int)Mathf.Round ((b - a) * val) + a;
	}


	int randInRange(int a, int b)
	{


		float val = 0;
		switch(generatorType)
		{
		case GeneratorType.degree:
			val = randInRangeDegree ();
			break;
		case GeneratorType.normal:
			val = randInRangeNormal ();
			break;
		case GeneratorType.perlin:
			val = perlinNoise ();
			break;
		case GeneratorType.simple:
			val = randInRangeSimple();
			break;
		case GeneratorType.superFlat:
			val = randInRangeFlat();
			break;
		}

		return (int)Mathf.Round ((b - a) * val) + a;
	}

	float randInRangeFlat()
	{
		float val = 0.5f;
		return val;
	}

	float randInRangeSimple()
	{
		float val = Random.value;
		return val;
	}

	float perlinNoise()
	{
		return Mathf.PerlinNoise ((float)i/(float)width*perlinScale, (float)j/(float)length*perlinScale);
	}


	float randInRangeNormal()
	{
		float p = Random.value;
		float sqr = Mathf.Sqrt (-2f * normalDistSigma * normalDistSigma * Mathf.Log (p * normalDistSigma * Mathf.Sqrt (2f * Mathf.PI)));
		float val = 0;
		if (Mathf.Round (Random.value) == 1) {
			//Debug.Log("-delta");
			val = 0.5f - sqr;
		} else {
			//Debug.Log("+delta");
			val = 0.5f + sqr;
		}
		
		return val;
	}


	float randInRangeDegree()
	{
		float scaledVal = 2f * (Random.value - 0.5f);
		float val = (float)System.Math.Pow (scaledVal, degreeDistDegree);
		if (scaledVal < 0 && val > 0)
				val *= -1f;

		val = val / 2f + 0.5f;

		return val;
	}
	
}
