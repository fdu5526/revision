using UnityEngine;
using System.Collections;

public class racingFriends : MonoBehaviour {
	public float basespeed;
	Animator myAnimator;
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
			
	}
	
	// Update is called once per frame
	void Update () {
		myAnimator.SetFloat("speedModifier", basespeed-TypingSpeed.speed);
	}
}
