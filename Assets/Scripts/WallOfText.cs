using UnityEngine;
using System.Collections;

public class WallOfText : MonoBehaviour {

	public int numberOfLines;
	public GameObject  linesPrefab;
	public string[] hiddenWord;
	public float initialDelay;
	bool wordUsed = false;
	int counter;
	int wordCounter;
	int lineWithWord;

	public Animator teacherAnimator;
	AudioSource teacherVoice;


	// Use this for initialization
	void Start () {
		teacherVoice = GetComponent<AudioSource> ();
		startWall();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startWall(){
		counter = 0;
		lineWithWord = (int)Random.Range(0, numberOfLines);
		StartCoroutine(generateWall());
	}

	IEnumerator generateWall(){
		teacherAnimator.SetTrigger("talk");
		teacherVoice.volume = 1;
		yield return new WaitForSeconds(initialDelay);

		while(counter < numberOfLines){
			GameObject tempGO = (GameObject)Instantiate(linesPrefab, transform.position, Quaternion.identity);
			if(counter == lineWithWord){
				tempGO.GetComponent<GenerateLineOfLetters>().preterminedWord = hiddenWord[wordCounter];
				wordCounter++;
				if (wordCounter >= hiddenWord.Length) {
					wordCounter = 0;
				}
			}
			yield return new WaitForSeconds(.2f);
			counter++;

			if(counter == numberOfLines){
				teacherAnimator.SetTrigger("idle");
				teacherVoice.volume = 0;
				yield return new WaitForSeconds(2f);
				lineWithWord = (int)Random.Range(0, numberOfLines);
				counter = 0;
				teacherAnimator.SetTrigger("talk");
				teacherVoice.volume = 1;
			}
		}
	}
}
