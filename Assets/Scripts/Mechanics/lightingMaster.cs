using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using Giverspace; // Needed to get access to logging

public class lightingMaster : MonoBehaviour {

	public GameObject[] AllGameObjects;
	public List<GameObject> AllGameObjectsWithShadows;
	public List<GameObject> AllLights;
	ShadowCastingMode castingVariable = ShadowCastingMode.Off;

	// Use this for initialization
	void Start () {
		AllGameObjects = GameObject.FindObjectsOfType<GameObject>();
		for(int i = 0; i < AllGameObjects.Length; i++){
			if(AllGameObjects[i].GetComponent<Renderer>() != null){
				AllGameObjectsWithShadows.Add(AllGameObjects[i]);
			}

			if(AllGameObjects[i].GetComponent<Light>() != null){
				AllLights.Add(AllGameObjects[i]);
			}
		}

		foreach(GameObject GO in AllGameObjectsWithShadows)
		{
			GO.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
			GO.GetComponent<Renderer>().receiveShadows = false;
		}

		foreach(GameObject GO in AllLights)
		{
			GO.GetComponent<Light>().shadowStrength = 0f;
			GO.AddComponent<castShadows>();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void turnOnAllShadows(){
		if(GameButtonMaster.ready){

		Log.Metrics.Message("Power-Lights");

		foreach(GameObject GO in AllGameObjectsWithShadows)
		{

			GO.GetComponent<Renderer>().receiveShadows = !GO.GetComponent<Renderer>().receiveShadows;
				if(GO.GetComponent<Renderer>().shadowCastingMode == ShadowCastingMode.On)
				{
					GO.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.Off;
					foreach(GameObject aLight in AllLights){
						aLight.GetComponent<castShadows>().startToggle(0f);
					}

				}
				else{
					GO.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.On;
					foreach(GameObject aLight in AllLights){
						aLight.GetComponent<castShadows>().startToggle(1f);
					}
				}
		}
			powerTracker.power[3] = !powerTracker.power[3];

		}
		else{
			Debug.Log("Button is not ready yet");
		}
	}
}
