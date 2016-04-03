using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityQueue : MonoBehaviour {

	public Ability[] abilities;

	// Use this for initialization
	void Start () {
	
		//StartCoroutine(runAbilities());

	}
	
	public void addAbility(Ability newAbility){
	/*	List<Ability> tempList = abilities;
		tempList.Add(newAbility);
		abilities = tempList;
	*/
	}

	public void startAbilities(){
		StartCoroutine(runAbilities());
	}

	IEnumerator runAbilities(){
		print("Running abilities");
		for(int i = 0; i < abilities.Length; i++){
			print("runnning abilities #"+i);
			abilities[i].Activate();
			yield return new WaitForSeconds(abilities[i].duration);
		}
	}
}
