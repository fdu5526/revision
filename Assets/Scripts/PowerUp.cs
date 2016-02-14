using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public GameObject display;

	// Use this for initialization
	void Start () {
        //SwitchDisplay();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Consume()
    {
        SwitchDisplay();
    }

    void SwitchDisplay()
    {
        display.GetComponent<Button>().image.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
