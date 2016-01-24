using UnityEngine;
using System.Collections;

public class soundForDuration : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(GetComponent<AudioSource>().volume>0){
			GetComponent<AudioSource>().volume -=.0025f;
		}
	}

	public void playClipForSeconds(){
		GetComponent<AudioSource>().volume = 1f;
	}


}
