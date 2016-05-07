using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HubButtonManager : MonoBehaviour {

	public Button[] hubButtons;
	public Button endingButton;
	public static int levelsVisited = 0;
	//public Button endButton;
	hubLevelSelector levelManager;

	// Use this for initialization
	void Start () {
		print ("Updating buttons");
		if (levelsVisited > 2) {
			endingButton.gameObject.SetActive (true);
		}
		levelManager = GameObject.FindObjectOfType<hubLevelSelector> ();
		bool nextLevel = true;
		for (int i = 0; i < gameProgress.levelsCompleted.LongLength; i++) {
			if(gameProgress.levelsCompleted[i] == true){
				hubButtons [i].interactable = false;
			}	
			if(gameProgress.levelsCompleted[i] == false){
				nextLevel = false;
			}
		}
		if (nextLevel) {
			levelManager.nextLevel ();
		}
	}

	public void levelVisited(){
		levelsVisited++;
		if (levelsVisited > 2) {
			endingButton.gameObject.SetActive (true);
		}
	}
}
