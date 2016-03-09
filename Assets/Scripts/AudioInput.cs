using UnityEngine;
using System.Collections;

public class AudioInput : MonoBehaviour {

	public GameObject activeOnTrigger;

  float maxTimePassToMoveOn = 8f;
  float timeStart;

  void Start () {
    string[] devs = Microphone.devices;
		print(devs.Length);
    GetComponent<AudioSource>().clip = Microphone.Start(devs[0], true, 10, 44100);
    timeStart = Time.time;
  }


  void MoveOn () {
    activeOnTrigger.SetActive(true);
    Destroy(gameObject);
  }

  void Update () {
    if (Time.time - timeStart > maxTimePassToMoveOn) {
      MoveOn();
      return;
    }

    AudioSource aud = GetComponent<AudioSource>();
    float[] samples = new float[aud.clip.samples * aud.clip.channels];
    aud.clip.GetData(samples, 0);
    int i = 0;
   
    while (i < samples.Length) {
      
      if(samples[i]>0.2f) {
        Debug.Log(samples[i]);
        //Debug.Log("The audio has been triggered and the number is: "+i);
        MoveOn();
        break;
      }
      ++i;
    }
    aud.Play();
  }
}