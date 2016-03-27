using UnityEngine;
using System.Collections;

public class racingSteve : MonoBehaviour {
	Animator myAnimator;
	public float speed = 0f;
	public AnimationCurve yCurve;
	public AnimationCurve scaleCurve;
	int typeCounter = 0;

	// Use this for initialization
	void Start () {
		//print ("curve at 0 seconds is: " + myCurve.Evaluate (0f));
		//print ("starting y value is: "+ transform.localPosition.y);
		gameObject.GetComponent<turn> ().turnAround ();
		myAnimator = GetComponent<Animator> ();
		Vector3 tempVect = transform.localPosition;

		//tempVect.y = mCurve.Evaluate (.9f);
		//transform.localPosition = tempVect;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (DebugSwitch.debugMode == false) {
			if (Input.anyKeyDown) {
				typeCounter += 3;
			}
			if (typeCounter > 0) {
				//myAnimator.Play ("animation_steve_walktest4", 0, 0);
				typeCounter--;
			}
			myAnimator.SetInteger ("racingSpeed", typeCounter);
	
		}
	}

	public void increaseSpeed(){
		speed += .1f;
		updateSpeed (speed);
	}

	public void updateSpeed(float speed){
		Vector3 charScale = transform.localScale;
		Vector3 charPos = transform.localPosition;
		float newScale = scaleCurve.Evaluate (speed);
	
		charPos.y = yCurve.Evaluate (speed);
		charScale = new Vector3 (newScale, newScale, newScale);

		transform.localScale = charScale;
		transform.localPosition = charPos;
	}
}
