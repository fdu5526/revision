using UnityEngine;
using System.Collections;



public class powerTracker : MonoBehaviour {

	/*
	public static bool grayscale;
	public static bool turned;
	public static bool shadow;
	public static bool perspective;
	*/

	public static bool[] power = new bool[5];
	public bool[] copyTracker;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < power.Length; i++){
			power[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		copyTracker = power;
	}
}
