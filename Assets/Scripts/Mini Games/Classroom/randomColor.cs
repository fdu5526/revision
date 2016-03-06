using UnityEngine;
using System.Collections;

public class randomColor : MonoBehaviour {

	public Color[] colors;

	// Use this for initialization
	void Start () {
		if(powerTracker.power[2] == false){
			GetComponent<Renderer>().material.color = colors[Random.Range(0,colors.Length)];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
