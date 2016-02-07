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
        initializeWord tempWord = other.gameObject.GetComponent<initializeWord>();
        if (tempWord != null)
        {
            confusionCounter++;
            questionMeter.text += "?";
        }
    }
}
