using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {

	byte counter = 150;
	// Use this for initialization
	void Start () {
		//StartCoroutine(momentaryFlash());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startFlash(){
		StartCoroutine(momentaryFlash());
	}

	public IEnumerator momentaryFlash(){
		Color32 tempColor = GetComponent<Renderer>().material.color;
		tempColor.a = counter;
		Debug.Log("Counter is: "+counter);
		counter +=50;
		if(counter < 150){
			Application.LoadLevel("racingEnd");
		}
		GetComponent<Renderer>().material.color = tempColor;
		while(tempColor.a>0){
			tempColor.a--;
			GetComponent<Renderer>().material.color = tempColor;
			yield return new WaitForSeconds(.001f);
			//yield return WaitForEndOfFrame;
		}
		//return null;
	}
}
