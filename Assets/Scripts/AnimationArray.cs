using UnityEngine;
using System.Collections;

public class AnimationArray : MonoBehaviour {

	public GameObject[] animatedObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	public void activateArray(){
		foreach (GameObject GO in animatedObjects) {
			GO.GetComponent<Animator> ().SetTrigger ("activate");
		}
	}
}
