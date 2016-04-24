using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StartingPosition{
	public string objectName;
	public Vector3 objectPosition;

	public StartingPosition(string newName, Vector3 newPosition){
		objectName = newName;
		objectPosition = newPosition;
	}
}

public class SetFriends : MonoBehaviour {

	//public StartingPositions[] friendPositions;
	public List<StartingPosition> listOfFriendsPositions;

	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start(){
	}


	public void rememberSpots(){
		friendMovement[] allTheFriends = GameObject.FindObjectsOfType<friendMovement>();
		print ("In rememberspots");
		foreach (friendMovement FM in allTheFriends) {
			print ("In FM loop");	
			listOfFriendsPositions.Add (new StartingPosition(FM.name, FM.transform.position));
		}
	}

	public void placeFriends(){
		print ("in placefriends");
		foreach (StartingPosition SP in listOfFriendsPositions) {
			print ("in placefriends SP loop");
			GameObject tempGO = GameObject.Find (SP.objectName);
			tempGO.transform.position = SP.objectPosition;
		}

	}
}
