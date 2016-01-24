using UnityEngine;
using System.Collections;

public class itemToggle : MonoBehaviour {
	public GameObject[] firstTimeObjects;
	public GameObject[] secondTimeObjects;
	// Use this for initialization
	void Start () {
	if(gameProgress.secondTime){
			Debug.Log("toggling off second play items");
			for(int i =0; i<secondTimeObjects.Length; i++){
				secondTimeObjects[i].SetActive(true);
			}
			for(int j = 0; j < firstTimeObjects.Length; j++){
				firstTimeObjects[j].SetActive(false);
			}
		}
		else{
			for(int i =0; i<secondTimeObjects.Length; i++){
				secondTimeObjects[i].SetActive(false);
			}
			for(int j = 0; j < firstTimeObjects.Length; j++){
				firstTimeObjects[j].SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
