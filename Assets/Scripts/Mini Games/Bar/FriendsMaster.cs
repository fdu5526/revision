using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Giverspace; // Needed to get access to logging

public class FriendsMaster : MonoBehaviour {

	public static bool debugged = false;

	friendMovement[] allFriends;
	friendSpot[] allSpots;
	public GameObject midpoint;
	// Use this for initialization
	void Start () {
		allFriends = GameObject.FindObjectsOfType<friendMovement>();
		allSpots= GameObject.FindObjectsOfType<friendSpot>();
	}
	
	public void resetStage(){
		Log.Metrics.Message("DebuggingStation");
		for(int i = 0; i<allFriends.Length; i++){
			allFriends[i].GetComponent<friendMovement>().leave();
		}
		debugged = true;
	}

	public void checkWin(){
		print ("Checking win");
		bool win = true;
		for(int i = 0; i<allSpots.Length; i++){
			if(allSpots[i].GetComponent<friendSpot>().occupant == null){
				win = false;
			}
		}
		if(win){
			endGame();
		}
	}

	public void placesPlease(){
		SetFriends[] tempGOs = GameObject.FindObjectsOfType<SetFriends> ();
		print ("There are exactly "+tempGOs.Length+" in this scene");
		foreach (SetFriends SF in tempGOs) {
			SF.placeFriends ();
		}
	}

	void endGame(){

		midpoint.SetActive(true);

	}
}
