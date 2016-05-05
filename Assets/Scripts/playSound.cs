using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour {
	AudioSource myAudio;
	// Use this for initialization

	void Start () {
		
	}

	void Awake(){
		myAudio = GetComponent<AudioSource> ();
		//myAudio.Play ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void activateSound(bool haha){
		myAudio.Play ();
	}

	public void changeVolume(float vol){
		myAudio.volume = vol;
	}

	public void upPitch(float increment){
		myAudio.pitch += increment;
	}
}
