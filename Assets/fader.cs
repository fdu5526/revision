using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {
	MeshRenderer[] meshedObjects;
	bool rendered = true;
	// Use this for initialization
	void Start () {
		meshedObjects = GetComponentsInChildren<MeshRenderer> ();
		//toggleFade ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleFade(){
		rendered = !rendered;
		for (int i = 0; i < meshedObjects.Length; i++) {
			meshedObjects [i].enabled = rendered;
		}
	}
}
