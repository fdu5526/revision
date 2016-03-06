using UnityEngine;
using System.Collections;

public class StopAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseUp()
	{
			transform.GetComponent<Animation>().Stop();
		}
	}