using UnityEngine;
using System.Collections;

public class message : MonoBehaviour {

	bool triggered = false;

	//message I send
	public Beat lines;

	//powers that trigger me

	public bool perspective;
	public bool turned;
	public bool grayscale;
	public bool shadow;
	public bool frame;
	bool[] boolArray = new bool[5];

	//space specific
	public bool spaceTrigger;
	bool inTriggerArea = false;

	// Use this for initialization
	void Start () {
	
		boolArray[0] = perspective;
		boolArray[1] = turned;
		boolArray[2] = grayscale;
		boolArray[3] = shadow;
		boolArray[4] = frame;

	}
	
	// Update is called once per frame
	void Update () {

		if(checkArray()){
	
			if(triggered == false){
				if (spaceTrigger == false){
					sendOutMessage();
					triggered = true;
				}
				else if (spaceTrigger == true && inTriggerArea == true){
					sendOutMessage();
					triggered = true;
				}
		}

		}
		if(!checkArray() && triggered == true){
			triggered = false;
	
		}
	}

	bool checkArray(){
		//Debug.Log("Checking Array");
		bool arrayMatch = true;
		for(int i = 0; i < powerTracker.power.Length; i++){
			if(powerTracker.power[i] != boolArray[i]){
				arrayMatch = false;
			}
		}
		//Debug.Log("ARray reads: "+arrayMatch);
		return arrayMatch;
	}

	void OnTriggerEnter(Collider other){

		if(other.tag == "Player"){
			inTriggerArea = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			inTriggerArea = false;
		}
	}

	void sendOutMessage(){
		//Debug.Log("Sending message");
		DialogueManager myManager = GameObject.FindObjectOfType<DialogueManager>();
		myManager.readTheLines(lines);
	}

}
