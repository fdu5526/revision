using UnityEngine;
using System.Collections;

public class WordBarf : MonoBehaviour {

	public GameObject letterPrefab;
	public string[] secretWords;
	public float vomitSize = 20;
	float directionModifier = 1;
	public GameObject MyBody;
	int projectileAngleModifier = 1;


	// Use this for initialization
	void Start () {
	//	barfRandomLetter();
	//	barfSpecificWord(0);
		StartCoroutine(babble());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator babble(){
		int counter = 0;
		while(true){
			MyBody.GetComponent<Animator>().Play("teacher_OpenMouth");
			string theWord = secretWords[counter];
			int stringLength = theWord.Length*3;
			int letterMarker = 0;
			for(int i = 0; i < stringLength; i++)
			{
				if(i % 3 == 0){
					barfSpecificWord(theWord, letterMarker);
					letterMarker++;
				}
				else {
					barfRandomLetter();
				}
				yield return new WaitForSeconds(.05f);
			}
			//keep this
			counter++;
			if(projectileAngleModifier==1){
				projectileAngleModifier = 0;
			}
			else{
				projectileAngleModifier = 1;
			}
			if(counter == secretWords.Length){
				counter = 0;
			}
			MyBody.GetComponent<Animator>().Play("teacher_CloseMouth");
			yield return new WaitForSeconds(3f);
		}
		//return null;
	}

	void barfRandomLetter(){
		GameObject tempGO = (GameObject)Instantiate(letterPrefab, transform.position, Quaternion.identity);
			if(powerTracker.power[2]){
				tempGO.GetComponent<Renderer>().material.color = Color.gray;
				
			}
		tempGO.GetComponent<addForce>().baseY = (0-projectileAngleModifier*10);
	}

	void barfSpecificWord(string word, int letter)
	{
			GameObject tempGO = (GameObject)Instantiate(letterPrefab, transform.position, Quaternion.identity);
			tempGO.GetComponent<initializeLetter>().predeterminedLetter = word[letter].ToString();
			tempGO.GetComponent<colorTracker>().preselectedColor = true;
			if(powerTracker.power[2]){
				tempGO.GetComponent<Renderer>().material.color = Color.black;
				
			}
		tempGO.GetComponent<addForce>().baseY = (0-projectileAngleModifier*10);
	}
}
