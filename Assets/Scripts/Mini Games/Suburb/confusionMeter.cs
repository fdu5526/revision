using UnityEngine;
using System.Collections;


public class confusionMeter : MonoBehaviour {
    static int confusionCounter = 0;
	static int goodCounter = 0;
    public TextMesh questionMeter;
	public GameObject endGameFlowchart;
	public GameObject noteFlowchart;
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
		if(confusionCounter>endGameThreshold && gameProgress.secondTime == false){
			endGameFlowchart.SetActive(true);
			this.enabled = false;
		}
	}

	public void confusionDown(){
		goodCounter++;
		if (goodCounter > 6) {
			noteFlowchart.SetActive (true);
		}
	}
}
