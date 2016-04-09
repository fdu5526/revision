using UnityEngine;
using System.Collections;

public class SetRotation : MonoBehaviour {
	public Vector3 newRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeToRotation(){
		gameObject.transform.localEulerAngles = newRotation;
	}
}
