using UnityEngine;
using System.Collections;

public class racingSpeedManager : MonoBehaviour {
	int counter;
	public int goal = 50;
	public int goalAmplifier;
	public float speedIncrement = .1f;
	movingPart[] allMovingParts;
	float playerSpeed;

	// Use this for initialization
	void Start () {
		allMovingParts = FindObjectsOfType<movingPart>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown){
			counter++;
		}
		if(counter > goal){
			speedUp();
		}	
	}

	public void pill(){
		//speedUp();
		StartCoroutine(burstSpeed(playerSpeed));
	}

	void speedUp(){
		playerSpeed += speedIncrement;
		updateSpeed(playerSpeed);
		counter = 0;
		goal *= goalAmplifier;
	}

	void updateSpeed(float newSpeed){
		foreach(movingPart MP in allMovingParts){	
			MP.UpdateSpeed(playerSpeed);
		}
	}

	IEnumerator burstSpeed(float originalSpeed){
		playerSpeed = 2f;
		updateSpeed(playerSpeed);
		yield return new WaitForSeconds(4f);
		playerSpeed = originalSpeed;
		speedUp();
	}
}
