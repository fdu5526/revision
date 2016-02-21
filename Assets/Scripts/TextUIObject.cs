using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUIObject : MonoBehaviour {

    [SerializeField]
    private Text _textObj;

	// Use this for initialization
	void Start () {
	
	}

    public void Initialize(string Text) {
        _textObj.text = Text;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
