using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	//public Dialogue[] someLines;

	public Beat[] theBeats = new Beat[5];
	public readLine[] allActorsInScene;

	//public bool nextLevelOnFinish;
	int lineMarker = 0;

	public enum eventAfterDialogue {activate, instantiate, nextLevel, nothing};
	public eventAfterDialogue afterTrigger;
	public GameObject[] objectAfterDialogue;

	// Use this for initialization
	void Start () {
		StartCoroutine("startBeats");
		allActorsInScene = FindObjectsOfType<readLine>() as readLine[];
	}
	
	// Update is called once per frame
	void Update () {

//		Debug.Log("Actor status are: "+checkActorsReady());

	if(Input.GetKeyDown(KeyCode.Return)){
			//check to see if all actors are done with their line
			bool tempBool = checkActorsReady();
			if(tempBool==true){
				StopCoroutine("startBeats");
				lineMarker++;
				StartCoroutine("startBeats");
			}
			else{
				Debug.Log("Not yet done");
			}
		}

	
	}

	bool checkActorsReady(){
		bool tempBool = true;
		for(int i = 0; i < allActorsInScene.Length; i++)
		{
			if(allActorsInScene[i].doneReading == false){
				tempBool = false;
			}
		}

		return tempBool;

	}

	IEnumerator startBeats(){
		while(lineMarker<theBeats.Length){
			readTheLines(theBeats[lineMarker]);
			yield return new WaitForSeconds(theBeats[lineMarker].duration);
			lineMarker++;
			if(lineMarker == theBeats.Length){
				if(afterTrigger == eventAfterDialogue.nextLevel){
					Application.LoadLevel(Application.loadedLevel+1);
				}
				if(afterTrigger == eventAfterDialogue.instantiate){
					for(int i = 0; i < objectAfterDialogue.Length; i++){
						GameObject nextStep = (GameObject)Instantiate(objectAfterDialogue[i], transform.position, Quaternion.identity);
					}
					Destroy(gameObject);
				}
				if(afterTrigger == eventAfterDialogue.activate){
					for(int i = 0; i < objectAfterDialogue.Length; i++){
						objectAfterDialogue[i].SetActive(true);
					}
					Destroy(gameObject);
				}

			}

		}
	}

	public void readTheLines(Beat currentBeat){
		Debug.Log("Starting beat");
		for(int i =0; i < currentBeat.beatLines.Length; i++){
			GameObject tempGO = GameObject.Find(currentBeat.beatLines[i].actor);
			tempGO.GetComponent<readLine>().readLines(currentBeat.beatLines[i].lines);
		}
	}
}
