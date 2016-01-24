using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dialogue {
	public string actor;
	public string lines;

	
	public Dialogue(string theActor, string theLines){
		actor = theActor;
		lines = theLines;
	}
}
