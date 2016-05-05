using UnityEngine;
using System.Collections;

public class suburbMinigameActivate : MonoBehaviour {

	public GameObject minigameStarter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startMinigame(){
		if (TranslateMaster.debugged == true) {
			minigameStarter.SetActive (true);
		}
	}		
}
