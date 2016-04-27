using UnityEngine;
using System.Collections;

public class gameProgress : MonoBehaviour {
	public static bool secondTime = false;
	public static bool[] levelsCompleted = new bool[5];
	// Use this for initialization
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("secondtime: "+secondTime);
			if(Input.GetKeyDown(KeyCode.PageUp))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if(Input.GetKeyDown(KeyCode.End))
			{
				Application.LoadLevel(Application.loadedLevel+1);
			}
	}

	public static void printGameLevelStatus(){
		for (int i = 0; i < levelsCompleted.Length; i++) {
			//levelsCompleted[i] = false;
			print ("Level "+i+" completion is: "+levelsCompleted[i]);
		}
	}

}
