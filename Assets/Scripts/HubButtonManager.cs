using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HubButtonManager : MonoBehaviour {

	public Button[] hubButtons; 
	//public Button endButton;
	hubLevelSelector levelManager;

	// Use this for initialization
	void Start () {
		print ("Updating buttons");
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
}
