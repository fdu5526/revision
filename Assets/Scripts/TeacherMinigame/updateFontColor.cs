using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(colorTracker))]
public class updateFontColor : MonoBehaviour {

	TextMesh myMesh;

	// Use this for initialization
	void Start () {
		myMesh = GetComponent<TextMesh>();
		GetComponent<colorTracker>().originalColor[0] = myMesh.color;
		GetComponent<colorTracker>().currentColor[0] = myMesh.color;
		GetComponent<Renderer>().material.color = myMesh.color;
	}
	
	// Update is called once per frame
	void Update () {
		myMesh.color = GetComponent<Renderer>().material.color;
	}
}
