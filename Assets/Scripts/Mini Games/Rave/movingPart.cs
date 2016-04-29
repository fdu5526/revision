using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class movingPart : MonoBehaviour {

	public float baseSpeed;
	float currentSpeed;
	float speedModifier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator>().SetFloat("speedModifier", TypingSpeed.speed);
	}

	public void UpdateSpeed(float newSpeed){
		
		//currentSpeed = GetComponent<Animator>().speed;
		//Debug.Log("new speed: "+GetComponent<Animator>().speed);
	}
}
