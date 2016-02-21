using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class LoggingSceneStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Log.Metrics.Message("SceneStart");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
