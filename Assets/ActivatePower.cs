using UnityEngine;
using System.Collections;

public class ActivatePower : MonoBehaviour {

    public Ability currentAbility;

	// Use this for initialization
	void Start () {
        currentAbility.Activate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
