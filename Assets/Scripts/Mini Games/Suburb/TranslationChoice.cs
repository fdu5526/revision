using UnityEngine;
using System.Collections;

public class TranslationChoice : MonoBehaviour {

	public bool correct;
	public confusionMeter myMeter;

	public GameObject correctAnswerFeedback;
	public GameObject wrongAnswerFeedback;

	public void checkAnswer(){
		if(correct == false){
			Debug.Log("WRONG");
			if (gameProgress.secondTime == false) {
				myMeter.confusionUp ();
			}
			Instantiate(wrongAnswerFeedback);
		}

		else{
			Instantiate(correctAnswerFeedback);
			TranslateMaster.upCounter ();
		}
		TranslateMaster.pause = false;
	}
}
