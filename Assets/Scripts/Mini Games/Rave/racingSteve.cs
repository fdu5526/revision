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
			myAnimator.SetInteger ("racingSpeed", typeCounter);
		}

		updateSpeed ();
	}

	public void updateSpeed(){
		/*
		Vector3 charScale = transform.localScale;
		Vector3 charPos = transform.localPosition;
		float newScale = scaleCurve.Evaluate (TypingSpeed.speed);
	
		charPos.y = yCurve.Evaluate (TypingSpeed.speed);
		charScale = new Vector3 (newScale, newScale, newScale);
		*/

		float charPosY = Mathf.Lerp(transform.localPosition.y, yCurve.Evaluate (TypingSpeed.speed), .1f);
		float newScale = Mathf.Lerp (transform.localScale.y, scaleCurve.Evaluate(TypingSpeed.speed), .1f);

		Vector3 charPos= new Vector3 (transform.localPosition.x, charPosY, transform.localPosition.z);
		Vector3 charScale= new Vector3(newScale, newScale, newScale);

		transform.localScale = charScale;
		transform.localPosition = charPos;
	}
}
