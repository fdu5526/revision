using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class DebugSwitch : MonoBehaviour {

	public static bool debugMode=false;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private Quaternion steveRotation;
	public GameObject PerspectiveCamera;
	public GameObject SteveModel;
	public GameObject TheController;

	// Use this for initialization
	void Start () {
		originalPosition = TheController.transform.position;
		originalRotation = TheController.transform.rotation;
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
		TheController.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = debugMode;
		if (debugMode == false){
			TheController.transform.position = originalPosition;
			TheController.transform.rotation = originalRotation;
			SteveModel.transform.rotation = steveRotation;
		}
	}

	public void Switching(){
		Log.Metrics.Message("DebuggingMode-" + (!debugMode ? "on" : "off"));
		StartCoroutine(SwitchMode());
	}
}
