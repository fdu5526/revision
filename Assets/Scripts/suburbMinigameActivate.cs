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
		print ("Translastermaster ddebug is:" +TranslateMaster.debugged);
		if (TranslateMaster.debugged == true) {
			print ("start minigame");
			minigameStarter.SetActive (true);
		}
	}		
}
