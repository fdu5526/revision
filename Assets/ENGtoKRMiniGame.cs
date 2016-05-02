using UnityEngine;
using System.Collections;

public class ENGtoKRMiniGame : MonoBehaviour {

    [SerializeField]
    private float _randTimerFloor;
    [SerializeField]
    private float _randTimerCeiling;

    [SerializeField]
    private Dictionary _dictionary;

    [SerializeField]
    private PanelSetup _panel;

    [SerializeField]
    private float _timer;

    [SerializeField]
    private GameObject _target;

	// Use this for initialization
	void Start () {
        _panel.ENGtoKR = true;
        _target.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (!_panel.gameObject.activeSelf) { 
            _timer -= Time.deltaTime;
        }

	    if (_timer < 0) {
            _panel.gameObject.SetActive(true);
            int RandomDictionaryInt = Random.Range(0, _dictionary.word.Length);
            _panel.ArrangePanel_ENGtoKR(_dictionary.word[RandomDictionaryInt]);
            _timer = Random.Range(_randTimerFloor, _randTimerCeiling);
        }
	}
}
