using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scaleSwitch : MonoBehaviour {

	public float targetScale;

	// Use this for initialization
	void Start () {
		//grow ();
		//Invoke ("revert", 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void grow(){
		Vector3 tempVector = new Vector3 (targetScale, targetScale, targetScale);
		transform.localScale = tempVector;
	}

	public void revert(){
		Vector3 tempVector = new Vector3 (1, 1, 1);
		transform.localScale = tempVector;
	}
}
