using UnityEngine;
using System.Collections;


public class confusionMeter : MonoBehaviour {
    static int confusionCounter = 0;
    public TextMesh questionMeter;
	public GameObject endGameFlowchart;
	public float endGameThreshold = 20;
	AnimationArray feedbackMachine;
	AudioSource momsVoice;
	// Use this for initialization
	void Start(){
		feedbackMachine = GameObject.FindObjectOfType<AnimationArray> ();
		momsVoice = GetComponent<AudioSource> ();
	}

    void OnTriggerEnter(Collider other) {
		print ("Collided with a " + other.name);
        words tempWord = other.gameObject.GetComponent<words>();
        if (tempWord != null)
        {
			confusionUp();
        }
    }

	public void confusionUp(){
		momsVoice.Play ();
		confusionCounter++;
		feedbackMachine.activateArray ();
		//questionMeter.text += "?";
		if(confusionCounter>endGameThreshold){
			endGameFlowchart.SetActive(true);
			this.enabled = false;
		}
	}
}
