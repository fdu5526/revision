using UnityEngine;
using System.Collections;

public class GenerateLineOfLetters : MonoBehaviour
{

	public int lineLength = 20;
	public GameObject letterPrefab;
	public string preterminedWord;

	//These are for pretermined word
	//Determines if the current letter is going to be a predetermined letter
	float chanceOfLetter;

	//How much of the entire line is left
	int spaceLeft;

	//How long the predetermined string is left. This number goes down.
	int lettersLeft;

	//Which letter is being put down
	int currentLetter = 0;

	// Use this for initialization
	void Start ()
	{

		lettersLeft = preterminedWord.Length;


		for (int i = 0; i < lineLength; i++) {
			spaceLeft = lineLength-i;
			Vector3 tempVect = transform.position;
			tempVect.x += i*.5f;
			GameObject tempGO = Instantiate (letterPrefab, tempVect, Quaternion.identity) as GameObject; 
			if (lettersLeft > 0) {
				if(checkChance()){
					tempGO.GetComponent<initializeLetter>().predeterminedLetter = preterminedWord[currentLetter].ToString();
					tempGO.GetComponent<colorTracker>().preselectedColor = true;
					if(powerTracker.power[2]){
						tempGO.GetComponent<Renderer>().material.color = Color.black;

					}
					currentLetter++;
					lettersLeft--;
				}


			}
		}
	}

	bool checkChance ()
	{
		//first, if there's not enough space if always returns true
		float tempFloat = Random.Range (0, 100f);
		if (lettersLeft == spaceLeft) {
			return true;
		} else if (tempFloat > 50f) {
			return true;
		} else {
			return false;
		}
	}
}
