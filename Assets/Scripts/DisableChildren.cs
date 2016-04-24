using UnityEngine;
using System.Collections;

[RequireComponent(typeof(friendSpot))]
public class DisableChildren : MonoBehaviour {

	public friendSpot mySpot;
	public GameObject[] myChildren;

	// Use this for initialization
	void Start () {
		mySpot = GetComponent<friendSpot> ();
		//myChildren = GetComponentsInChildren<GameObject> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (mySpot.occupant != null) {
			for (int i = 0; i < myChildren.Length; i++) {
				myChildren [i].SetActive (false);
			}
			this.enabled = false;
		}
	}
}
