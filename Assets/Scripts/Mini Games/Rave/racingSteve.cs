using UnityEngine;
using System.Collections;

public class racingSteve : MonoBehaviour {

	public float speed = 0f;
	public AnimationCurve yCurve;
	public AnimationCurve scaleCurve;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<turn> ().turnAround ();
	}
	
	// Update is called once per frame
	void Update () {
		updateSpeed ();
	}

	public void updateSpeed(){
		float charPosY = Mathf.Lerp(transform.localPosition.y, yCurve.Evaluate (TypingSpeed.speed), .1f);
		float newScale = Mathf.Lerp (transform.localScale.y, scaleCurve.Evaluate(TypingSpeed.speed), .1f);

		Vector3 charPos= new Vector3 (transform.localPosition.x, charPosY, transform.localPosition.z);
		Vector3 charScale= new Vector3(newScale, newScale, newScale);

		transform.localScale = charScale;
		transform.localPosition = charPos;
	}
}
