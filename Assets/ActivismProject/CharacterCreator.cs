using UnityEngine;
using System.Collections;

public class CharacterCreator : MonoBehaviour {

	public GameObject[] models;
	public string[] names;

	// Use this for initialization
	void Start () {
		createCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createCharacter(){
		int randomIntChar = (int)Random.Range (0, models.Length);
		int randomIntName = (int)Random.Range (0, names.Length);
		int randomIntProd = (int)Random.Range (0, 3);
		int randomIntCost = (int)Random.Range (0, 3);
		GameObject newCharacter = Instantiate (models [randomIntChar], transform.position, Quaternion.identity) as GameObject;
		newCharacter.AddComponent<Pickup> ();
		Farmer newFarmer = newCharacter.AddComponent<Farmer> ();
		newFarmer.characterName = names [randomIntName];
		newFarmer.productivity = randomIntProd;
		newFarmer.cost = randomIntCost;
	}
}
