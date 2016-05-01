using UnityEngine;
using System.Collections;

public class speechBillboard : MonoBehaviour {
	Transform camera;
	[SerializeField] bool _flip;
	[SerializeField] Transform _followCharacter;
//	[SerializeField] float _yOffset = 0f;

	void Awake () {
		camera = Camera.main.transform;
	}

	void LateUpdate () {
		Vector3 lookAtCamera = (camera.position - transform.position);
		lookAtCamera.y = 0;
		//keep the x coordinate still
//		lookAtCamera.x = transform.position.x;
		transform.forward = _flip? -lookAtCamera : lookAtCamera;

//		transform.position = new Vector3 (_followCharacter.transform.position.x, _followCharacter.transform.position.y + _yOffset, _followCharacter.transform.position.z);
		transform.position = new Vector3 (_followCharacter.transform.position.x, transform.position.y, _followCharacter.transform.position.z);

	}
}
