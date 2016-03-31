using UnityEngine;
using System.Collections;

public class hubLevelSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameProgress.secondTime = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.PageUp)) {
			nextLevel ();
		}
	}

	public void jumpToLevel(string levelName){
		if (DebugSwitch.debugMode) {
			DebugSwitch.debugMode = false;
		}
		Application.LoadLevel(levelName);
	}

	public void nextLevel(){
		int tempInt = Application.loadedLevel;
		tempInt++;
		Application.LoadLevel(tempInt);
	}


}
