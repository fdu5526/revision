using UnityEngine;
using System.Collections;

public class mashchecker : MonoBehaviour {
	int numberOfLoops = 3;
	int secondsBetweenLoops = 8;
	public toggleImage imagetotoggle;
	// Use this for initialization
	void Start () {
		StartCoroutine (checkSpeed ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator checkSpeed(){
		int counter = 0;
		while (counter < numberOfLoops) {
			yield return new WaitForSeconds (secondsBetweenLoops);
			if (TypingSpeed.speed < .2f) {
				imagetotoggle.switchImage ();
				yield return new WaitForSeconds (1);
				imagetotoggle.switchImage ();
			}
			counter++;
		}
	}

}
