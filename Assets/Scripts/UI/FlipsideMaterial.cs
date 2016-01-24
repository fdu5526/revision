using UnityEngine;
using System.Collections;

public class FlipsideMaterial : MonoBehaviour {

    [SerializeField]
    private GameObject _parentObj;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material = _parentObj.GetComponent<Renderer>().material;
	}
}
