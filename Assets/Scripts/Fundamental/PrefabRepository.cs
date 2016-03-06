using UnityEngine;
using System.Collections;

public class PrefabRepository : MonoBehaviour {

	public GameObject[] Prefabs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instantiatePrefab(int prefabNumber){
		GameObject newPrefab = (GameObject)Instantiate(Prefabs[prefabNumber], transform.position, Quaternion.identity);
	}
}
