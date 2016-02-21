using UnityEngine;
using System.Collections;

public class switchLayer : MonoBehaviour {

	// Use this for initialization
	void Start () { 
		//switchMyLayer();
		//string newlayer = "raveBG";

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchMyLayer(){
		gameObject.layer = LayerMask.NameToLayer("RaveBG");
		StartCoroutine(backToDefault());

	}
	IEnumerator backToDefault(){
		yield return new WaitForSeconds(2f);
		gameObject.layer = LayerMask.NameToLayer("Default");
	}
}
