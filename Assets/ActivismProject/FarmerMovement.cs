using UnityEngine;
using System.Collections;

public class FarmerMovement : MonoBehaviour {

	public bool pickedUp = false;
	public float snapDistance = 2f;

	GameObject nearestObject;
	Vector3 originalPosition;

	void Start () {
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (pickedUp)
		{
			followMouse();
		}
	}

	void OnMouseDown()
	{
			pickedUp = true;
			if (nearestObject != null && nearestObject.GetComponent<friendSpot>().occupant == gameObject)
			{
				nearestObject.GetComponent<friendSpot>().occupant = null;
			}
	}

	void OnMouseUp()
	{
		pickedUp = false;
		snapToPosition();
	}

	void followMouse()
	{
		Vector3 tempvector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tempvector.z = transform.position.z;
		transform.position = tempvector;
	}

	void snapToPosition()
	{
		findNearest();
		float distanceToNearestObject = Vector3.Distance(transform.position, nearestObject.transform.position);
		if (distanceToNearestObject < snapDistance && nearestObject.GetComponent<friendSpot>().occupant == null)
		{
			//setInSpot ();
			transform.position = nearestObject.transform.position;
			//print (nearestObject.name+" set to me because snap to position");
			nearestObject.GetComponent<friendSpot>().occupant = gameObject;
			nearestObject.GetComponent<friendSpot>().checkOthers();
		}
		else
		{
			transform.position = originalPosition;
		}
	}

	IEnumerator move(Vector3 target)
	{
		float distanceToTarget = Vector3.Distance(transform.position, target);
		yield return new WaitForSeconds(.5f);
		while (distanceToTarget>.1f)
		{
			transform.position = Vector3.Lerp(transform.position, target, 1f*Time.deltaTime);
			distanceToTarget = Vector3.Distance(transform.position, target);
			if (distanceToTarget < .5f)
			{
				transform.position = target;
				distanceToTarget = 0;
			}
			yield return null;
		}
		yield return null;
	}

	public void react(string haha){
	}

	public void leave()
	{
		//print ("leaving");	
		if(nearestObject != null){
			//print (nearestObject.name + " set to null because leave");
			nearestObject.GetComponent<friendSpot>().occupant = null;
		}
		StartCoroutine(move(originalPosition));
	}

	void findNearest()
	{
		GameObject[] spots = GameObject.FindGameObjectsWithTag("Spot");
		//Debug.Log("Found "+spots.Length+" spots");


		nearestObject = spots[0];
		for(int i = 1; i < spots.Length; i++)
		{
			float distanceToNearestObject = Vector3.Distance(transform.position, nearestObject.transform.position);
			float distanceToCurrentObject = Vector3.Distance(transform.position, spots[i].transform.position);
			if(distanceToNearestObject > distanceToCurrentObject && spots[i].GetComponent<friendSpot>().occupant == null)
			{
				nearestObject = spots[i];
			}
		}
	}
	//Calls function in bubbleResize.cs that resizes the speech bubble
	//Used to detect when speech changes
}
