using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrayscaleMaterialSwitch : Ability {

	// Use this for initialization
	public GameObject[] AllGameObjects;
	public colorTracker[] AllGameObjectsOfColor;
	public bool grayscaleOn = false;

	void Start () {
	//find all gameobjects with materials

		AllGameObjects = GameObject.FindObjectsOfType<GameObject>();
		for(int i = 0; i < AllGameObjects.Length; i++){
			if(AllGameObjects[i].GetComponent<Renderer>() != null && AllGameObjects[i].GetComponent<colorTracker>() == null){
				AllGameObjects[i].AddComponent<colorTracker>();
			}
		}
	}


	public void toggleGrayscale(){
		if(GameButtonMaster.ready){
			
			grayscaleOn = !grayscaleOn;
			powerTracker.power[2]=!powerTracker.power[2];
			AllGameObjectsOfColor = GameObject.FindObjectsOfType<colorTracker>();
			for(int i = 0; i < AllGameObjectsOfColor.Length; i++){
				AllGameObjectsOfColor[i].orderedToChange(grayscaleOn);
				
			}
		}
		else{
			Debug.Log("Button is not ready yet");
		}
	}

    public override void Activate()
    {
        toggleGrayscale();
    }
}
