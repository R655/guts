using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

	public float speed = 0.1f;
	public float sensitive = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = Vector3.zero;
		/*if(Input.GetKeyDown(KeyCode.W))
			direction = Vector3.forward;
		else if(Input.GetKeyDown(KeyCode.A))
			direction = Vector3.left;
		else if(Input.GetKeyDown(KeyCode.S))
			direction = Vector3.back;
		else if(Input.GetKeyDown(KeyCode.D))
			direction = Vector3.right;*/
		direction = Vector3.right*Input.GetAxis ("Horizontal");
		direction += Vector3.forward*Input.GetAxis ("Vertical");
		if (Input.GetButton ("Fire3")) 
		{
			gameObject.transform.Translate (-direction * speed);
			gameObject.transform.Rotate (
				new Vector3 (
				Input.GetAxis ("Mouse Y"), 
				Input.GetAxis ("Mouse X"))
				* sensitive);
		}
		else
		{
			//gameObject.transform.Rotate (
				//new Vector3 (Input.GetAxis("Mouse ScrollWheel"), 0f)
				//* sensitive*(-5f));
			gameObject.transform.Translate (Input.GetAxis("Mouse ScrollWheel")*Vector3.forward * sensitive);
			gameObject.transform.position += direction * speed;
		}

	}
}
