using UnityEngine;
using System.Collections;

public class trackTarget : MonoBehaviour {

	public Transform target;

	public float minDistanceToTarget = 1f; //distance at which you start moving
	public float maxDistanceToTarget = 20f; // distance at which to move faster

	float distanceToTarget;

	public float baseSpeed=1.5F;
	public float acceleration=.1f;
	public float maximumSpeed = 2f;


	public bool moving;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distanceToTarget = Vector3.Distance(transform.position, target.position);

		if (distanceToTarget>maxDistanceToTarget){
			moving = true;
		}

		if (distanceToTarget<minDistanceToTarget){
			moving = false;
		}

		if(moving){
			transform.position = Vector3.MoveTowards(transform.position, target.position, baseSpeed*Time.deltaTime);
		}

	}
}
