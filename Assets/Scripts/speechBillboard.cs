using UnityEngine;
using System.Collections;

public class speechBillboard : MonoBehaviour {
	Transform camera;
	[SerializeField] bool flip;

	void Awake () {
		camera = Camera.main.transform;
	}

	void Update () {
		Vector3 lookAtCamera = (camera.position - transform.position);
		lookAtCamera.y = 0;
		//keep the x coordinate still
//		lookAtCamera.x = transform.position.x;
		transform.forward = flip? -lookAtCamera : lookAtCamera;
	}
}
