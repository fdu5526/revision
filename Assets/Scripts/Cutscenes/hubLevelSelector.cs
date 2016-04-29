using UnityEngine;
using UnityEngine.SceneManagement;
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

		if (Input.GetKeyDown (KeyCode.PageDown)) {
			SceneManager.LoadScene(0);
		}
	}

	public void jumpToLevel(string levelName){
		if (DebugSwitch.debugMode) {
			DebugSwitch.debugMode = false;
		}
		SceneManager.LoadScene (levelName, LoadSceneMode.Single);
		//Application.LoadLevel(levelName);
	}

	public void nextLevel(){
		//int tempInt = Application.loadedLevel;
		int tempInt = SceneManager.GetActiveScene().buildIndex;
		tempInt++;
		//Application.LoadLevel(tempInt);
		SceneManager.LoadScene (tempInt, LoadSceneMode.Single);
	}


}
