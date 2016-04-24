using UnityEngine;
using System.Collections;

public class ActivateArray : MonoBehaviour {

	public GameObject[] objectsToActivate;
	public float interval;
	int counter=0;
	// Use this for initialization
	void Start () {
		StartCoroutine (activateTheArray ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator activateTheArray(){
		while (counter < objectsToActivate.Length) {
			objectsToActivate [counter].SetActive (true);
			counter++;
			yield return new WaitForSeconds (interval);
		}
	}
}
