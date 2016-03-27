using UnityEngine;
using System.Collections;

public class turn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void turnAround(){
		Vector3 tempVect = transform.eulerAngles;
		tempVect.y *= -1f;
		transform.eulerAngles = tempVect;
	}
}
