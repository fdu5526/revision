using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour {
	AudioSource myAudio;
	// Use this for initialization

	void Start () {
		
	}

	void Awake(){
		myAudio = GetComponent<AudioSource> ();
		myAudio.Play ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void activateSound(bool haha){
		myAudio.Play ();
	}
}
