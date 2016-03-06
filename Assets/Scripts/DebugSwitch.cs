using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class DebugSwitch : MonoBehaviour {

	public static bool debugMode=false;
	public cameraSettingToggle cameraSystem;
	//private Quaternion steveRotation;
	//public GameObject PerspectiveCamera;
	//public GameObject SteveModel;
	//public GameObject TheController;

	// Use this for initialization
	void Start () {

		//steveRotation = SteveModel.transform.rotation;
		//StartCoroutine(SwitchMode());
	}

	public void SwitchMode(){
		Log.Metrics.Message("DebuggingMode-" + (!debugMode ? "on" : "off"));
		debugMode = !debugMode;
		cameraSystem.switchMode();
		//PerspectiveCamera.GetComponent<PerspectiveSwitcher>().switchPerspective();
		//yield return new WaitForSeconds(2f);
		//Quaternion tempVect = SteveModel.transform.localRotation;
		//tempVect.y *= -1;
		//SteveModel.transform.rotation = tempVect;
		//cameraSystem.toggleMode(debugMode);
		//if (debugMode == false){
		//cameraSystem.resetPosition();
		//SteveModel.transform.rotation = steveRotation;
		//}
	}
		
}
