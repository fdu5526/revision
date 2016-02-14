using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resetStage(){
		
		for(int i = 0; i<allFriends.Length; i++){
			allFriends[i].GetComponent<friendMovement>().leave();
		}
		debugged = !debugged;
	}

	public void checkWin(){
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

	void endGame(){

		midpoint.SetActive(true);

	}
}
