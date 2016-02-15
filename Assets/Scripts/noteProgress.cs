using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class noteProgress : MonoBehaviour {

	public static int totalNotes;
	public static int notesFound;

	// Use this for initialization
	void Start () {
		GameObject[] tempNotes = GameObject.FindGameObjectsWithTag("Note");
		totalNotes = tempNotes.Length;
		updateText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateText(){

		string tempString = notesFound.ToString()+"/"+totalNotes.ToString()+" notes found";
		//Debug.Log(tempString);
		gameObject.GetComponent<Text>().text = tempString;
	}

	public void addNote(){
		notesFound++;
		updateText();
	}

}
