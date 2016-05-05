using UnityEngine;
using System.Collections;

public class DestroyAll : MonoBehaviour {

	public string TypeToDestroy;
	public GameObject[] Destructee;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyTagged(){
		Destructee = GameObject.FindGameObjectsWithTag (TypeToDestroy);
		foreach (GameObject GO in Destructee) {
			Destroy (GO);
		}
	}
}
