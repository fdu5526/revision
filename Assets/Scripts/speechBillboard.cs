using UnityEngine;
using System.Collections;

public class speechBillboard : MonoBehaviour {
	Transform camera;
	[SerializeField] bool _flip;
	[SerializeField] Transform _followCharacter;

	void Awake () {
		camera = Camera.main.transform;
	}

	void Update () {
		Vector3 lookAtCamera = (camera.position - transform.position);
		lookAtCamera.y = 0;
		//keep the x coordinate still
//		lookAtCamera.x = transform.position.x;
		transform.forward = _flip? -lookAtCamera : lookAtCamera;

		transform.position = new Vector3 (_followCharacter.transform.position.x, transform.position.y, _followCharacter.transform.position.z);
	}
}
