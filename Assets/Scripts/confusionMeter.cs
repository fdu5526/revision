using UnityEngine;
using System.Collections;

public class confusionMeter : MonoBehaviour {
    static int confusionCounter = 0;
    public TextMesh questionMeter;
	public GameObject endGameFlowchart;
	public float endGameThreshold = 20;
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
		if(confusionCounter>endGameThreshold){
			endGameFlowchart.SetActive(true);
			this.enabled = false;
		}
	}
}
