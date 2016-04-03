using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassroomInputField : MonoBehaviour {

	[SerializeField]
	PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
		playerMovement.SetPause(true);
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
