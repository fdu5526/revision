using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class animationSetup : MonoBehaviour {
	Animator anim;
	public string animationName;
	public float startingFrame;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(animationName != null && startingFrame != 0){
		anim.Play(animationName, 0, startingFrame);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			//reverseAnimation();
		}
	}

	public void reverseAnimation(){
		//anim.pla
	}
}
