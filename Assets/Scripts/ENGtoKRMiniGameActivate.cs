using UnityEngine;
using System.Collections;

public class ENGtoKRMiniGameActivate : MonoBehaviour {

    [SerializeField]
    private ENGtoKRMiniGame _miniGame;

    [SerializeField]
    private Spawner[] _spawners;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (_miniGame.enabled) {
            foreach (Spawner x in _spawners) {
                x.enabled = false;
            }
        }
	}
}
