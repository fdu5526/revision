using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class racingSpeedManager : MonoBehaviour {
	int counter;
	public int goal = 50;
	public int goalAmplifier;
	public float speedIncrement = .1f;
	movingPart[] allMovingParts;
	float playerSpeed;
	racingSteve steve;

	// Use this for initialization
	void Start () {
		allMovingParts = FindObjectsOfType<movingPart>();
		steve = FindObjectOfType<racingSteve> ();
	}
	  
	// Update is called once per frame
	void Update () {
		if (gameProgress.secondTime == false) {
			if (Input.anyKeyDown) {
				counter++;
			}
			if (counter > goal) {
				speedUp ();
			}	
		}
	}

	public void pill(){
		//speedUp();
		//print("Pill button");
		if (DebugSwitch.debugMode == false) {
			StartCoroutine (burstSpeed (playerSpeed));
		}
	}

	void speedUp(){
		playerSpeed += speedIncrement;
		updateSpeed(playerSpeed);
		counter = 0;
		goal *= goalAmplifier;
		steve.increaseSpeed ();
	}

	void updateSpeed(float newSpeed){
		foreach(movingPart MP in allMovingParts){	
			MP.UpdateSpeed(playerSpeed);
		}
	}

	IEnumerator burstSpeed(float originalSpeed){
		playerSpeed = 2f;
		updateSpeed(playerSpeed);
		steve.updateSpeed (.7f);
		yield return new WaitForSeconds(4f);
		playerSpeed = originalSpeed;
		steve.updateSpeed (steve.speed);
		speedUp();
	}
}
