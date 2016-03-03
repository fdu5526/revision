using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class initializeLetter : MonoBehaviour {

	public string predeterminedLetter;
	TextMesh myMesh;

	// Use this for initialization
	void Start () {
		myMesh = GetComponent<TextMesh>();
		if(predeterminedLetter == ""){
			myMesh.text = RandomLetter.generateLetter();
		}
		else{
			myMesh.text = predeterminedLetter;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
