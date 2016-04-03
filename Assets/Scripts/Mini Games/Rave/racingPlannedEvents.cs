using UnityEngine;
using System.Collections;

public class racingPlannedEvents : MonoBehaviour {

	public GameObject thePill;
	int counter = 0;
	public int numberOfTimes = 2;
	public GameObject endSceneDialogue;

	// Use this for initialization
	void Start () {
		thePill.gameObject.SetActive(false);

		if (gameProgress.secondTime == false) {
			StartCoroutine (firstAppearance ());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pillCycle(){

		StartCoroutine(resetPill());
	}

	public IEnumerator firstAppearance(){
		yield return new WaitForSeconds(5f);
		StartCoroutine(pause(5f));
		thePill.gameObject.SetActive(true);
		//yield return null;
	}

	public IEnumerator pause(float duration){
		yield return new WaitForSeconds(duration);
	}

	public IEnumerator resetPill(){
		checkForGameOver();
		thePill.gameObject.SetActive(false);
		yield return new WaitForSeconds(5f);
		thePill.gameObject.SetActive(true);
		yield return null;
	}

	void checkForGameOver(){
	if(gameProgress.secondTime == false){
			counter++;
			if (counter > numberOfTimes){
				endSceneDialogue.SetActive(true);
				Destroy(thePill,1);
				Destroy(gameObject,1);
			}
		}
	}
}
