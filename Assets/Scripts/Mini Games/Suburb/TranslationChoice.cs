using UnityEngine;
using System.Collections;

public class TranslationChoice : MonoBehaviour {

	public bool correct;
	public confusionMeter myMeter;

	public GameObject correctAnswerFeedback;
	public GameObject wrongAnswerFeedback;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void checkAnswer(){
		if(correct == false){
			Debug.Log("WRONG");
			myMeter.confusionUp();
			Instantiate(wrongAnswerFeedback);

		}
		else{
			Instantiate(correctAnswerFeedback);
		}
	
		TranslateMaster.pause = false;

	}
}
