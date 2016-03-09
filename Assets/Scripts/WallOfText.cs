using UnityEngine;
using System.Collections;

public class WallOfText : MonoBehaviour {

	public int numberOfLines;
	public GameObject  linesPrefab;
	public string hiddenWord;
	public float initialDelay;
	bool wordUsed = false;
	int counter;
	int lineWithWord;


	// Use this for initialization
	void Start () {
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
		yield return new WaitForSeconds(initialDelay);

		while(counter < numberOfLines){
			GameObject tempGO = (GameObject)Instantiate(linesPrefab, transform.position, Quaternion.identity);
			if(counter == lineWithWord){
				tempGO.GetComponent<GenerateLineOfLetters>().preterminedWord = hiddenWord;
			}
			yield return new WaitForSeconds(.2f);
			counter++;

			if(counter == numberOfLines){
				yield return new WaitForSeconds(2f);
				counter = 0;
			}
		}
	}
}
