using UnityEngine;
using System.Collections;

public class TypingSpeed : MonoBehaviour {
	static float charactersTyped;
	public static float speed;
	private bool playerInput = true;
	// Use this for initialization
	void Start () {
		StartCoroutine (wordPerSecond());
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInput) {
			if (Input.anyKeyDown) {
				charactersTyped++;
			}

			if (DebugSwitch.debugMode == true) {
				speed = 0;
			}
		}
	}

	IEnumerator wordPerSecond(){
		while (DebugSwitch.debugMode == false) {
			yield return new WaitForSeconds (1);
			if (playerInput) {
				speed = charactersTyped / 60f;
			}
			charactersTyped = 0;

		}
	}

	public void pill(){
		if (DebugSwitch.debugMode == false) {
			StartCoroutine (burstSpeed ());
		}
	}

	IEnumerator burstSpeed(){
		playerInput = false;
		speed = .9f;
		yield return new WaitForSeconds(4f);
		playerInput = true;
	}
}
