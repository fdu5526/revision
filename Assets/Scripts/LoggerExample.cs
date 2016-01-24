using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class LoggerExample : MonoBehaviour {


	void Start () {
        // Example of logging a string directly --
        //   this is not preferred because it has a greater chance of causing frame hitches due to garbage collection
        Log.Metrics.Message("Here's a string message example!");
	}

	void Update () {
       // Example of tracking position and orientation every frame
	   Log.Metrics.PlayerPosRotMessage(transform.position, transform.forward);
	}
}
