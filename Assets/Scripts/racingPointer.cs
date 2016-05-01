using UnityEngine;
using System.Collections;

public class racingPointer : MonoBehaviour {
	Vector3 tempVector3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateRotation ();
	}

	void updateRotation (){
		tempVector3 = transform.localEulerAngles;
		tempVector3.z = Mathf.Lerp (tempVector3.z, (160+TypingSpeed.speed * (100f)), .1f);
		transform.localEulerAngles = tempVector3;
	}
}
