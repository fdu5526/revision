using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public bool pickedUp = false;
	public float snapDistance = 2f;
	GameObject nearestObject;
	Vector3 originalPosition;
	public NodeManager theNodeManager;

	void Start(){
		theNodeManager = GameObject.FindObjectOfType<NodeManager> ();
	}
	// Use this for initialization
	void Update () {
		if (pickedUp)
		{
			followMouse();
		}
	}

	void followMouse()
	{
		Vector3 tempvector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tempvector.y = transform.position.y;
		transform.position = tempvector;
	}

	void OnMouseDown()
	{
		if(DebugSwitch.debugMode == false){
			Debug.Log("picked up");
			pickedUp = true;
		}

	}

	void OnMouseUp()
	{
		Debug.Log("put down");
		pickedUp = false;
		snapToPosition();
	}

	void snapToPosition()
	{
		findNearest();
		float distanceToNearestObject = Vector3.Distance(transform.position, nearestObject.transform.position);
		if (distanceToNearestObject < snapDistance && nearestObject.GetComponent<friendSpot>().occupant == null)
		{
			transform.position = nearestObject.transform.position;
			nearestObject.GetComponent<friendSpot>().occupant = gameObject;
			theNodeManager.updatePairs ();
			Destroy (this);
		}
		else
		{
			transform.position = originalPosition;
		}
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
}
