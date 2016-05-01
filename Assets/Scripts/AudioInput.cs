using UnityEngine;
using System.Collections;

public class AudioInput : MonoBehaviour {

	public GameObject activeOnTrigger;

  float maxTimePassToMoveOn = 8f;
  float timeStart;
  float timeToMoveOnAfterInput = 4f;
  bool isListening;

  void Start () {
    string[] devs = Microphone.devices;
		print(devs.Length);
		if(devs[0] !=null){
		GetComponent<AudioSource>().clip = Microphone.Start(devs[0], true, 10, 44100);
		}
    timeStart = Time.time;
    isListening = true;
  }


  void MoveOn () {
    activeOnTrigger.SetActive(true);
    Destroy(gameObject);
  }

  void Update () {
    if (!isListening) {
      return;
    }
    if (Time.time - timeStart > maxTimePassToMoveOn) {
      isListening = false;
      MoveOn();
      return;
    }

    AudioSource aud = GetComponent<AudioSource>();
    float[] samples = new float[aud.clip.samples * aud.clip.channels];
    aud.clip.GetData(samples, 0);
    int i = 0;
   
    while (i < samples.Length) {
      
      if(samples[i]>0.2f) {
        //Debug.Log("The audio has been triggered and the number is: "+i);
        isListening = false;
        Invoke("MoveOn", timeToMoveOnAfterInput);
        break;
      }
      ++i;
    }
    aud.Play();
  }
}