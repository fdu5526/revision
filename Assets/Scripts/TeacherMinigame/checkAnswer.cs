using UnityEngine;
using System.Collections;

public class checkAnswer : MonoBehaviour {
	public string[] correctAnswers;
	public GameObject[] prizes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void checkTheAnswer(string answer){
		bool right = false;
		for(int i = 0; i<correctAnswers.Length; i++){
		if(answer==correctAnswers[i]){
				right = true;
			}
		}
	if(right){
			Debug.Log ("You got it right!");
			for(int j=0;j<prizes.Length; j++){
				prizes[j].SetActive(true);
			}
			GameObject.FindObjectOfType<PlayerMovement>().zAxisMovementEnabled=true;
		}
	}
}
