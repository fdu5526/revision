using UnityEngine;
using System.Collections;


public class confusionMeter : MonoBehaviour {
    static int confusionCounter = 0;
    public TextMesh questionMeter;
	public GameObject endGameFlowchart;
	public float endGameThreshold = 20;
	AnimationArray feedbackMachine;
	// Use this for initialization
	void Start(){
		feedbackMachine = GameObject.FindObjectOfType<AnimationArray> ();
	}

    void OnTriggerEnter(Collider other) {
        words tempWord = other.gameObject.GetComponent<words>();
        if (tempWord != null)
        {
			confusionUp();
        }
    }

	public void confusionUp(){
		confusionCounter++;
		feedbackMachine.activateArray ();
		//questionMeter.text += "?";
		if(confusionCounter>endGameThreshold){
			endGameFlowchart.SetActive(true);
			this.enabled = false;
		}
	}
}
