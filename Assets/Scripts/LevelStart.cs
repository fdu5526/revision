using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

	public GameObject[] first;
	public GameObject[] second;

	void Awake(){

		print("In level loaded");
		if(gameProgress.secondTime == false){
			foreach(GameObject GO in first){
				GO.SetActive(true);
			}
		}

		if(gameProgress.secondTime){
			foreach(GameObject GO in second){
				GO.SetActive(true);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
