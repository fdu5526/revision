using UnityEngine;
using System.Collections;

public class gameProgress : MonoBehaviour {
	public static bool secondTime = true;
	public static bool[] levelsCompleted = new bool[5];
	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
		
	public static void printGameLevelStatus(){
		for (int i = 0; i < levelsCompleted.Length; i++) {
			//levelsCompleted[i] = false;
			print ("Level "+i+" completion is: "+levelsCompleted[i]);
		}
	}

}
