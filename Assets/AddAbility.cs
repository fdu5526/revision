using UnityEngine;
using System.Collections;

public class AddAbility : MonoBehaviour {

	public Ability abilityAdded;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && abilityAdded != null){
			cameraSettingToggle cameraT = GameObject.FindObjectOfType<cameraSettingToggle>();
			cameraT.gameModeChanges = abilityAdded;
			//queue.abilities.
		}
	}

}
