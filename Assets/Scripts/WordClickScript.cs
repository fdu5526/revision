using UnityEngine;
using System.Collections;

public class WordClickScript : MonoBehaviour {

    [SerializeField]
    private int _wordStringCount;

	// Use this for initialization
	void Awake () {
        _wordStringCount = GetComponent<TextMesh>().text.Length;
        GetComponent<BoxCollider>().size = new Vector3(_wordStringCount*5 / 8, 1f, 1f);
	}

    void OnMouseDown() {
        Debug.Log("HELLO I WILL TRANSFER");
    }
}
