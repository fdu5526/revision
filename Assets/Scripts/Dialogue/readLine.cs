using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class readLine : MonoBehaviour {

	public bool doneReading = false;
	public GameObject mouth;
	TextMesh myTextMesh;

	void Start(){
		myTextMesh = GetComponent<TextMesh>();
	}

	public void readLines(string myLines){
		Debug.Log("starting my lines");
		StartCoroutine(updateMyLines(myLines));
	}

	public IEnumerator updateMyLines(string completeLine){
		string message = "";
		AudioSource myAudio = GetComponent<AudioSource>();
		if(myAudio != null){
			GetComponent<AudioSource>().Play();
		}
		for(int i=0; i<completeLine.Length; i++){
			message += completeLine[i];
			yield return new WaitForSeconds(.05f);
			//gameObject.GetComponent<Text>().text=message;
			myTextMesh.text = message;

			if(mouth !=null){
			if(i==completeLine.Length-1){
				mouth.GetComponent<Animator>().SetBool("talking", false);
				doneReading = true;
			}
			else{
				mouth.GetComponent<Animator>().SetBool("talking", true);
				doneReading = false;
			}
			}
		}
	}

}
