using UnityEngine;
using System.Collections;

public class IntroBranch : MonoBehaviour {

	public string avatarName;
	public GameObject SteveFlowchart;
	public GameObject OtherFlowchart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeName(string input){
		avatarName = input;
		Debug.Log("Avatar name is: "+avatarName);
	}

	public void nextStep(){
		if(avatarName == "Steve" || avatarName == "steve"){
			SteveFlowchart.SetActive(true);
		}
		else{
			OtherFlowchart.SetActive(true);
		}
	}
}
