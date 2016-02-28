using UnityEngine;
using System.Collections;

public class AudioInput : MonoBehaviour {

	public GameObject activeOnTrigger;

    void Start () {
        string[] devs = Microphone.devices;
		print(devs.Length);
        GetComponent<AudioSource>().clip = Microphone.Start(devs[0], true, 10, 44100);
    }


    void Update () {
            AudioSource aud = GetComponent<AudioSource>();
            float[] samples = new float[aud.clip.samples * aud.clip.channels];
            aud.clip.GetData(samples, 0);
            int i = 0;
           
            while (i < samples.Length) {
              //  Debug.Log(samples[i]);
                 if(samples[i]>0.2f){
                 //Debug.Log("The audio has been triggered and the number is: "+i);
				activeOnTrigger.SetActive(true);
					Destroy(gameObject);
                 }
                ++i;
            }
            aud.Play();
    }
}