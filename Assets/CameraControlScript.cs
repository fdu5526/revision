using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

    private float _inputX;
    private float _inputY;

    [SerializeField]
    private float _cameraRotationSpeed = 2;
    [SerializeField]
    private float _cameraMoveSpeed = 2;

    [SerializeField]
    private GameObject _objectOfInterest;
    [SerializeField]
    private GameObject _playerObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ManageMouseMovement();
        ManageCameraPosition();
	}

    void ManageMouseMovement() {
        if (_objectOfInterest == null) { 
            _inputX = Input.GetAxis("Mouse X");
            _inputY = Input.GetAxis("Mouse Y");

            transform.localEulerAngles += new Vector3(_inputY, _inputX, 0f) * _cameraRotationSpeed;
        }
    }

    void ManageCameraPosition() {
        if (_objectOfInterest != null) { 
            transform.position = Vector3.MoveTowards(transform.position, _objectOfInterest.transform.position, Time.deltaTime * _cameraMoveSpeed);
        }
        else {
            transform.position = _playerObject.transform.position;
        }
    }
}
