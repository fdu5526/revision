using UnityEngine;
using System.Collections;

public class MomOutsideDetection : MonoBehaviour {

    [SerializeField]
    private MomDetector _momDetector;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Mom") {
            _momDetector.SetMomState(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Mom")
        {
            _momDetector.SetMomState(false);
        }
    }
}
