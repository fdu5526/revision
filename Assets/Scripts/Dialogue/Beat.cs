using UnityEngine;
using System.Collections;

[System.Serializable]
public class Beat {

	public float duration;
	public Dialogue[] beatLines;

	public Beat(float length, Dialogue[] directions){
		beatLines = directions;
		duration = length;
	}

	public Beat(float length, Dialogue directions){
		beatLines = new Dialogue[1];
		beatLines[0] = directions;
		duration = length;
	}
}
