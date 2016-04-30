using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FarmMaster : MonoBehaviour {
	public static int money = 0;
	public static int enemyMoney = 0;
	public static int propertyCost = 20;
	public Text playerMoneyDisplay;
	public Text enemyMoneyDisplay;
	friendSpot[] allSpots;
	FarmerTile[] allTiles;
	// Use this for initialization
	void Start () {
		allSpots = GameObject.FindObjectsOfType<friendSpot> ();	
		allTiles = GameObject.FindObjectsOfType<FarmerTile> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerMoneyDisplay.text = "$" + money;
		enemyMoneyDisplay.text = "$" + enemyMoney;
	}

	public void earnings(){
		int playerPoints = 0;
		int enemyPoints = 0;
		enemyBuys ();
		foreach (friendSpot FS in allSpots) {
			if (FS.occupant != null) {
				playerPoints++;
				enemyPoints++;
				enemyPoints++;
			}	
		}

		foreach(FarmerTile FT in allTiles){
			if (FT.myOwner == FarmerTile.Owner.family) {
				playerPoints++;
			}

			if (FT.myOwner == FarmerTile.Owner.enemy) {
				enemyPoints++;
			}
		}

		money += (playerPoints * 5);
		enemyMoney += (enemyPoints * 5);

		FarmerMovement[] allFriends = GameObject.FindObjectsOfType<FarmerMovement> ();
		foreach (FarmerMovement FM in allFriends) {
			FM.leave ();
		}

	
	}

	public void setMoney(int newMoney){
		money = newMoney;
		enemyMoney = newMoney;
	}

	public void subtractMoney(int newMoney){
		money -= newMoney;
	}

	void enemyBuys (){
		for (int i = 0; i < allTiles.Length; i++) {
			if (enemyMoney >= propertyCost && allTiles [i].myOwner == FarmerTile.Owner.none) {
				enemyMoney -= propertyCost;
				allTiles [i].enemyOwned ();
			}
		}
	}
}
