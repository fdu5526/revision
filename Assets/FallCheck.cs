using UnityEngine;
using System.Collections;
using Fungus;

public class FallCheck : MonoBehaviour {
	Transform playerTransform;
	public GameObject warning;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.y < this.transform.position.y) {
			warning.SetActive (true);
		}
	}
}
