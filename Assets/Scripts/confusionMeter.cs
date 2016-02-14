using UnityEngine;
using System.Collections;

public class confusionMeter : MonoBehaviour {
    static int confusionCounter = 0;
    public TextMesh questionMeter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        words tempWord = other.gameObject.GetComponent<words>();
        if (tempWord != null)
        {
			confusionUp();
        }
    }

	public void confusionUp(){
		confusionCounter++;
		questionMeter.text += "?";
	}
}
