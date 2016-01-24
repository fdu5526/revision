using UnityEngine;
using System.Collections;

public class RandomLetter {

	static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string generateLetter(){
		string a = alphabet[Random.Range(0,alphabet.Length)].ToString(); 
		return a;
	}
}
