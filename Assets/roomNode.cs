using UnityEngine;
using System.Collections;

public class roomNode : MonoBehaviour {
	public GameObject[] nodes = new GameObject[4];
	public float maxRayDistance = 20f;
	// Use this for initialization
	void Start () {
		//UpdateAdjacent();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay(transform.position, transform.forward, Color.green);
	}

	void UpdateAdjacent(){
		RaycastHit myRay;
		//raycast. if his, becomes roomnode[i]
		for (int i = 0; i < nodes.Length; i++) {

			Vector3 newRotation = transform.eulerAngles;
			newRotation.y = i * 90f;
			transform.eulerAngles = newRotation;


			if (Physics.Raycast (transform.position, transform.forward, out myRay, maxRayDistance)) {
				if (myRay.transform.tag == "Node") {
					nodes [i] = myRay.transform.gameObject;
				} else {
					nodes [i] = null;
				}

			}

		}

		//then rotates, repeat
	}

	Transform randomTransform(){
		Transform newTransform = null;
		int tempInt = (int)Random.Range (0, nodes.Length);
		while (nodes[tempInt]== null) {
			tempInt = (int)Random.Range (0, nodes.Length);
		}
		newTransform = nodes [tempInt].transform;
		return newTransform;
	}

	void OnTriggerEnter(Collider other){
		momMovement familyMember = other.GetComponent<momMovement>() as momMovement;
		if (familyMember!= null) {
			UpdateAdjacent ();
			familyMember.origin = familyMember.destination;
			familyMember.destination = randomTransform ();
		}
	}
}
