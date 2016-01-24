using UnityEngine;
using System.Collections;

public class randomlines : MonoBehaviour {

	TextMesh myMesh;
	public string[] lines;
	// Use this for initialization
	void Start () {
		myMesh = GetComponent<TextMesh>();
		StartCoroutine(cycleLines());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator cycleLines(){
	while(true){
			yield return new WaitForSeconds(5f);
			int tempInt = (int)Random.Range(0, lines.Length);
			myMesh.text = lines[tempInt];
			AudioSource myAudio = GetComponent<AudioSource>();
			if(myAudio != null){
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
