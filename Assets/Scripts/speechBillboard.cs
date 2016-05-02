using UnityEngine;
using System.Collections;

public class speechBillboard : MonoBehaviour {
	Transform camera;
	[SerializeField] bool _flip;
	[SerializeField] Transform _followCharacter;
//	[SerializeField] float _yOffset = 0f;
    SceneTransition _sceneTrans;
    float _yPos;
    float _yPosCenter;

	void Awake () {
		camera = Camera.main.transform;
        _sceneTrans = _followCharacter.GetComponent <SceneTransition> ();
        _yPos = transform.position.y;
        _yPosCenter = _yPos + 3.6f;
	}

	void LateUpdate () {
		Vector3 lookAtCamera = (camera.position - transform.position);
		lookAtCamera.y = 0;
		//keep the x coordinate still
//		lookAtCamera.x = transform.position.x;
		transform.forward = _flip? -lookAtCamera : lookAtCamera;

        if (_sceneTrans._isSteveCenter == true) {
            transform.position = new Vector3 (_followCharacter.transform.position.x, _yPosCenter, _followCharacter.transform.position.z);
        } else {
//		transform.position = new Vector3 (_followCharacter.transform.position.x, _followCharacter.transform.position.y + _yOffset, _followCharacter.transform.position.z);
            transform.position = new Vector3 (_followCharacter.transform.position.x, _yPos, _followCharacter.transform.position.z);
        }
	}
}
