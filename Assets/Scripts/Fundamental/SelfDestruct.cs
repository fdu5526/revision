using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float countdown;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, countdown);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
