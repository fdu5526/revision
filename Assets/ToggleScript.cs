using UnityEngine;
using System.Collections;

public class ToggleScript : MonoBehaviour {

	public PlayerControllerTest targetScript;


	public void toggleControls(){
		targetScript.enabled = !targetScript.enabled;
	}
}
