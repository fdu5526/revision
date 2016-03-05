using UnityEngine;
using System.Collections;

public class cameraSettingToggle : MonoBehaviour {
	//So it remembers where game mode's default camera is

	//Entire GO's start position
	public Vector3 startingSystemPosition;
	private Quaternion startingSystemRotation;

	//CameraPivot's starting position
	public GameObject cameraPivot;
	private Vector3 startingCameraPosition;
	private Quaternion startingCameraRotation;

	//Camera for PerspectiveSwitch
	private PerspectiveSwitcher theCamera;

	//these get toggled on and off with debug mode
	public CameraControlScript cameraController;
	public PlayerControllerTest playerController;

	//these are used for the model
	public GameObject playerModel;
	private Quaternion playerStartRotation;

	public Ability gameModeChanges;



	// Use this for initialization
	void Start () {
	
		//set starting values
		startingSystemPosition = transform.position;
		startingSystemRotation = transform.rotation;
		startingCameraPosition = cameraPivot.transform.position;
		startingCameraRotation = cameraPivot.transform.rotation;
		playerStartRotation = playerModel.transform.rotation;

		//grab camera
		theCamera = GetComponentInChildren<PerspectiveSwitcher>();
	}
	
	public void toggleControls(bool mode){
		cameraController.enabled= mode;
		playerController.enabled = mode;
	}

	public void resetPosition(){
		transform.position = startingSystemPosition;
		transform.rotation = startingSystemRotation;
		cameraPivot.transform.position = startingCameraPosition;
		cameraPivot.transform.rotation = startingCameraRotation;
	}

	public void switchMode(){

//		theCamera.switchPerspective();
//		turnPlayerModel();
//		toggleControls(DebugSwitch.debugMode);
//		if(DebugSwitch.debugMode == true){
//		}
//		else{
//			resetPosition();
//		}

		StartCoroutine(switching());
	}

	public IEnumerator switching(){
		theCamera.switchPerspective();
		yield return new WaitForSeconds(4f);
		turnPlayerModel();
		toggleControls(DebugSwitch.debugMode);
		if(DebugSwitch.debugMode == true){
		}
		else{
			resetPosition();
			if(gameModeChanges != null){
				gameModeChanges.Activate();
				gameModeChanges = null;
			}
		}
	}

	public void turnPlayerModel(){
		if(DebugSwitch.debugMode == true){
			Quaternion tempVect = playerModel.transform.localRotation;
			tempVect.y *= -1;
			playerModel.transform.rotation = tempVect;
		}
		else{playerModel.transform.rotation = playerStartRotation;}
	}
}
