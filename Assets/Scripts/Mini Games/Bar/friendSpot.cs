using UnityEngine;
using System.Collections;

public class friendSpot : MonoBehaviour {
    public GameObject occupant;
    public GameObject[] neighbor;
    // Use this for initialization

    public void checkOthers()
    {
        //call reaction from all neighbors
        //Debug.Log("Calling on neighbors to react");
        for(int i = 0; i < neighbor.Length; i++)
        {
            neighbor[i].GetComponent<friendSpot>().react(occupant.name);
        }
    }

    public void react(string ohLook)
    {
        //Debug.Log("I, "+name+", am reacting to "+ohLook);
        if(occupant != null)
        {
			friendMovement tempFriendMovement = occupant.GetComponent<friendMovement> ();
			if (tempFriendMovement != null) {
				occupant.GetComponent<friendMovement> ().reactTo (ohLook);
			}
        }
    }
}
