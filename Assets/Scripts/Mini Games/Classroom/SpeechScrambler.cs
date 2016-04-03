using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechScrambler : MonoBehaviour {



	public char[] unscrambledLetters;
	string newString;
	string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string scrambleLetters(string unscrambledText){

		newString = " ";

		//creating a new string
		for(int i = 0; i < unscrambledText.Length; i++){
		
			bool exemptFromScramble = false;

			//Is it exempt from scrambling?
			for(int j = 0; j < unscrambledLetters.Length; j++){

				if (unscrambledText[i] == unscrambledLetters[j]){
					exemptFromScramble = true;
					}
			}

			//then you add it to the string
			if(exemptFromScramble){
				newString += unscrambledText[i];
			}

			else{
				newString += alphabet[Random.Range(0,alphabet.Length)];
			}


		}

		return newString;
	}

	public void scrambleDialogue(string newLine){
		TextMesh myMesh = GetComponent<TextMesh>();
		print("Saying my new line: "+newLine);
		myMesh.text = scrambleLetters(newLine);
		//Debug.Log("Here's the scrambled version: "+scrambleLetters(newLine));
		//DialogueManager scripter = GameObject.FindObjectOfType<DialogueManager>();
		//Dialogue tempDialogue = new Dialogue("SteveText", scrambleLetters(newLine));
		//Dialogue tempLines[1] = {tempDialogue};
		//Beat tempBeat = new Beat(2f, tempDialogue);
		//scripter.readTheLines(tempBeat);
	}

}
