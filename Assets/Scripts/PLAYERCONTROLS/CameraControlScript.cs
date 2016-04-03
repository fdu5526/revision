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
    private Transform _mainCamera;
    private Vector3 _mainCameraPosition;
    private Quaternion _mainCameraRotation;
	[SerializeField]
    private bool _continueRotate;

    [SerializeField]
    private Transform _objectOfInterest;
    [SerializeField]
    private GameObject _playerObject;

    [SerializeField]
    private float _scrollSpeed;

    private bool _playerControlled;

    private Vector3 _currentRotation;

    [SerializeField]
    private Transform _lookAtTarget;

    public void PlayerControlled(bool activate, Transform target) {
        _playerControlled = activate;
        _lookAtTarget = target;
    }

    public void SetObjectOfInterest(Transform objectOfInterest) {
        _objectOfInterest = objectOfInterest;
    }

    public void StopViewingObject() {
        _objectOfInterest = null;
        _playerControlled = true;
        _lookAtTarget = null;
		PlayerControllerTest.movementEnabled = true;
    }
	
    void Start() {
        PlayerControlled(true, null);
    }

	// Update is called once per frame
	void Update () {
        ManageMouseMovement();
        ManageCameraPosition();
        ManageCameraZoom();
	}

    void ManageMouseMovement() {

        // THIS IS FOR TESTING PURPOSES
        // START HERE
        if (Input.GetKeyDown(KeyCode.F1)) {
            StopViewingObject();
        }
        // END TEST

        if (_playerControlled) { 
            if (_objectOfInterest == null) { 
                _inputX = Input.GetAxis("Mouse X");
                _inputY = Input.GetAxis("Mouse Y");

				transform.localEulerAngles += new Vector3(_inputY, _inputX, 0f) * _cameraRotationSpeed;
				_mainCamera.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);


                if (_continueRotate) {

					if (Vector3.Distance(_mainCamera.localEulerAngles, new Vector3(0f, 0f, 0f)) < 1.5f &&
						Vector3.Distance(_mainCamera.position, (_playerObject.transform.position + new Vector3 (0f, 0f, -10f))) < 1)
                    {
                        _continueRotate = false;    
                    }
                }
            }
        }
        else {
            if (_lookAtTarget != null) {
                _mainCamera.rotation = Quaternion.Slerp(_mainCamera.rotation, _lookAtTarget.rotation, Time.deltaTime * _cameraRotationSpeed);
                _continueRotate = true;
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            PlayerControlled(true, null);
            _objectOfInterest = null;
        }
    }

    void ManageCameraPosition() {
        if (_lookAtTarget != null) { 
            transform.position = Vector3.Slerp(transform.position, _lookAtTarget.position, Time.deltaTime * _cameraMoveSpeed/4);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, _playerObject.transform.position, Time.deltaTime * _cameraMoveSpeed);
        }
    }

    void ManageCameraZoom() {

        float MouseScrollAmount = Input.GetAxis("Mouse ScrollWheel");

        if (MouseScrollAmount != 0)
        {
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(1f, 1f, 1f) * MouseScrollAmount * transform.localScale.x;
            transform.localScale = Vector3.Slerp(transform.localScale, newScale, Time.deltaTime * _scrollSpeed);
        }
    }
}
