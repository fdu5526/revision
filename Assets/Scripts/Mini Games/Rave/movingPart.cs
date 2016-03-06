using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class movingPart : MonoBehaviour {

	public float baseSpeed;
	public bool slowsdown;
	float currentSpeed;
	float speedModifier;

	// Use this for initialization
	void Start () {

		GetComponent<Animator>().SetFloat("speedModifier", baseSpeed);
	if(slowsdown == true){
			speedModifier = -1f;
		}
		else{
			speedModifier = 1f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateSpeed(float newSpeed){
		GetComponent<Animator>().SetFloat("speedModifier", baseSpeed+(speedModifier*newSpeed));
		//currentSpeed = GetComponent<Animator>().speed;
		//Debug.Log("new speed: "+GetComponent<Animator>().speed);
	}
}
