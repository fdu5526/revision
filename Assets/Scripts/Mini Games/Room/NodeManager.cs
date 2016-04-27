using UnityEngine;
using System.Collections;

[System.Serializable]
public class pair{
	public friendSpot[] spots;
	public GameObject[] activatedItems;
	//public GameObject[] deactivatedItems;

	public pair(friendSpot[] theSpots, GameObject[] items){
		spots = theSpots;
		activatedItems = items;
	}

	public void checkNodes(){
	
		bool turnOn = true;

		for (int i = 0; i < spots.Length; i++) {
			if (spots [i].occupant == null) {
				turnOn = false;
			}
		}

		if (turnOn == true) {
			for (int k = 0; k < activatedItems.Length; k++) {
				activatedItems [k].SetActive (true);
			}
		}

	}
}

public class NodeManager : MonoBehaviour {
	public pair[] thePairs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updatePairs(){
		for (int i = 0; i < thePairs.Length; i++) {
			thePairs [i].checkNodes ();
		}
	}
}
