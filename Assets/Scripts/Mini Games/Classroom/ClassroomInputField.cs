using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using Fungus;

public class ClassroomInputField : MonoBehaviour {

	//public Flowchart myFlowchart;
	[SerializeField]
	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement.SetPause(true);
		//myFlowchart.SetStringVariable ("Answer", "haha this works");
	}
	
	public void Activate (bool activate) {
		playerMovement.SetPause(activate);
		PlayerControllerTest.movementEnabled = true;
		gameObject.SetActive(activate);
	}

	void FixedUpdate () {
		playerMovement.SetPause(true);
		PlayerControllerTest.movementEnabled = false;
	}
}
