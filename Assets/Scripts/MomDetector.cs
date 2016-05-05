using UnityEngine;
using System.Collections;

public class MomDetector : MonoBehaviour {

    [SerializeField]
    private bool _momState;

    [SerializeField]
    private GameObject[] _highlightBoxes;

	// Use this for initialization
	void Start () {
	
	}

    public void SetMomState(bool State) {
        _momState = State;
    }

    public bool ReturnMomState() {
        return _momState;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_momState) {
            foreach (GameObject x in _highlightBoxes) {
                x.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject x in _highlightBoxes)
            {
                x.SetActive(false);
            }
        }
	}
}
