using UnityEngine;
using System.Collections;

public class FarmerTile : MonoBehaviour {

	public enum Owner{none, enemy, family}; 
	public GameObject myTile;
	public Owner myOwner;

	// Use this for initialization
	void Start () {

		myTile = transform.GetChild(0).gameObject;
		updateTile ();
	}
	
	void OnMouseDown(){
		if (FarmMaster.money >= FarmMaster.propertyCost && myOwner == Owner.none) {
			FarmMaster.money -= FarmMaster.propertyCost;
			myOwner = Owner.family;
			updateTile ();
		}
			
	}

	public void familyOwned(){
		myOwner = Owner.family;
		updateTile ();
	}

	public void enemyOwned(){
		myOwner = Owner.enemy;
		print ("bought by enemy");
		updateTile ();
	}

	public void noneOwned(){
		myOwner = Owner.none;
		updateTile ();
	}


	void updateTile(){
		switch (myOwner) {
		case Owner.none:
			myTile.GetComponent<MeshRenderer> ().material.color = Color.gray;
			this.tag = "Untagged";
			break;
		case Owner.enemy:
			myTile.GetComponent<MeshRenderer> ().material.color = Color.red;
			this.tag = "Untagged";
			break;
		case Owner.family:
			myTile.GetComponent<MeshRenderer> ().material.color = Color.green;
			this.tag = "Spot";
			break;
		default:
			Debug.Log("Trigger ineffective");
			break;
		}
	}
}
