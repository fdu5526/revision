using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class DebugSwitch : MonoBehaviour {

	public static bool debugMode=false;
	private Quaternion steveRotation;
	public cameraSettingToggle cameraSystem;
	public GameObject PerspectiveCamera;
	public GameObject SteveModel;
	public GameObject TheController;

	// Use this for initialization
	void Start () {

		steveRotation = SteveModel.transform.rotation;

		//StartCoroutine(SwitchMode());
	}

	public IEnumerator SwitchMode(){

		debugMode = !debugMode;
		PerspectiveCamera.GetComponent<PerspectiveSwitcher>().switchPerspective();
		yield return new WaitForSeconds(2f);
		Quaternion tempVect = SteveModel.transform.localRotation;
		tempVect.y *= -1;
		SteveModel.transform.rotation = tempVect;
		cameraSystem.toggleMode(debugMode);
		if (debugMode == false){
			cameraSystem.resetPosition();
			SteveModel.transform.rotation = steveRotation;
		}
	}

	public void Switching(){
		Log.Metrics.Message("DebuggingMode-" + (!debugMode ? "on" : "off"));
		StartCoroutine(SwitchMode());
	}
}
