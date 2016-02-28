using UnityEngine;
using System.Collections;

public class cameraSettingToggle : MonoBehaviour {

	//So it remembers where game mode's default camera is
	public Vector3 startingSystemPosition;
	public Quaternion startingSystemRotation;

	public GameObject theCamera;
	public Vector3 startingCameraPosition;
	public Quaternion startingCameraRotation;

	//these get toggled on and off with debug mode
	public CameraControlScript cameraController;
	public PlayerControllerTest playerController;


	// Use this for initialization
	void Start () {
		startingSystemPosition = transform.position;
		startingSystemRotation = transform.rotation;

		startingCameraPosition = theCamera.transform.position;
		startingCameraRotation = theCamera.transform.rotation;
	}
	
	public void toggleMode(bool mode){
		cameraController.enabled= mode;
		playerController.enabled = mode;
	}

	public void resetPosition(){
		transform.position = startingSystemPosition;
		transform.rotation = startingSystemRotation;
		theCamera.transform.position = startingCameraPosition;
		theCamera.transform.rotation = startingCameraRotation;
	}
}
