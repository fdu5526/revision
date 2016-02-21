using UnityEngine;
using System.Collections;


public class RotateLightBeam : MonoBehaviour {
	//public float interval;
	public float speed = 100.0f;


	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.RotateAround(Vector3.zero, Vector3.up,speed * Time.deltaTime);
		transform.Rotate(0,0,speed*Time.deltaTime, Space.Self);
//		Quaternion rot = transform.rotation;
//		rot.y += speed * Time.deltaTime;
//		transform.rotation = rot;

	
	}
}
