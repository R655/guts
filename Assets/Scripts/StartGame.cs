using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public int SizeWidth = 50;
	public int SizeLength = 50;
	public bool[,] Coordinates;
	public Transform  homePrefab;
	public Transform  gutPrefab;
	public Transform BackgroundPlane;
	// Use this for initialization
	void Start () {
		int i, j,G;
		Transform Bplane;
		Coordinates = new bool[SizeWidth,SizeLength];
		Bplane = Instantiate(BackgroundPlane, new Vector3(SizeWidth/2,0,-SizeLength/2),BackgroundPlane.rotation) as Transform;
		for (i=SizeWidth/2; i<SizeWidth; i++) 
		{
				
			for(j=SizeLength/2; i<SizeLength;i++)
			{
				if (Coordinates[i,j]==false)
				{
					Transform GutHome;
					Transform Gut;
					GutHome = Instantiate(homePrefab, new Vector3(i,0,-j),homePrefab.rotation) as Transform;
					for (G=0;G<=6;G++)
						Gut = Instantiate(gutPrefab, new Vector3(i,0,-j),gutPrefab.rotation) as Transform;
					transform.position = new Vector3(i,5,-(j+5));
					transform.LookAt(GutHome);
					break;
				}
				
			}
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
