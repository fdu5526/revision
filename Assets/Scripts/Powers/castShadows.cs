using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Light))]
public class castShadows : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void startToggle(float target){
		//StartCoroutine(toggleShadow(target));
		Light myLight = GetComponent<Light>();
		myLight.shadowStrength = 1f;
	}

	public IEnumerator toggleShadow(float target){

		float elapsedTime = 0.0f;
		float totalTime = 3.0f;

		Light myLight = GetComponent<Light>();
		float current = myLight.shadowStrength;

		while(elapsedTime<totalTime){
			//GameButtonMaster.ready = false;
		
			current = Mathf.Lerp(current, target, (elapsedTime / (totalTime*10f)));
			myLight.shadowStrength = current;
			
			elapsedTime+=Time.deltaTime;
			
			if(elapsedTime>totalTime){

				current = target;
				myLight.shadowStrength = current;
			//	GameButtonMaster.ready = true;
			}
			yield return null;
		}
		

	}
}
