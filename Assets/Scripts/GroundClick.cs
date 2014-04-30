using UnityEngine;
using System.Collections;

public class GroundClick : MonoBehaviour {

	void Start ()
	{
		Random.seed = (int)Time.time;
	}
	 
	public int i = 0;
	public int j = 0;
	
	void OnMouseDown ()
	{
		float r = Random.Range(0f,1f);
		float g = Random.Range(0f,1f);
		float b = Random.Range(0f,1f);
		Color randomColour = new Color(r,g,b,1f);
		
		renderer.material.color = randomColour;
	}
}
