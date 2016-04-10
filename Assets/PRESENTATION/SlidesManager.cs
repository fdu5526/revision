using UnityEngine;
using System.Collections;

public class SlidesManager : MonoBehaviour {
	public Material[] theSlides;
	int counter = 0;
	// Use this for initialization
	void Start () {
		counter = 1;
		GetComponent<MeshRenderer> ().material = theSlides [counter];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Alpha9)) {
			counter++;
			print (counter);
			updateTexture ();
		}

		if (Input.GetKeyUp (KeyCode.Alpha0)) {
			counter--;
			print (counter);
			updateTexture ();
		}

	}

	void updateTexture(){
		if (counter < 0) {
			counter = 0;
		}
		if (counter >= theSlides.Length) {
			counter = theSlides.Length - 1;
		}
		GetComponent<MeshRenderer> ().material = theSlides [counter];
	}
}
