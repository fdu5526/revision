using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleImage : MonoBehaviour {

	bool toggle = false;
	Image myImage;

	// Use this for initialization

	void Start () {
		myImage = GetComponent<Image>();
		myImage.enabled=toggle;
		//print("I have an image! It is called: "+myImage.name);
	}

	public void switchImage(){
		toggle = !toggle;
		myImage.enabled=toggle;
	}
}
