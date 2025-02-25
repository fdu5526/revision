﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	[SerializeField] MinMax _zoomLimit = new MinMax(-1f, 2f);
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
    private bool _mouseEnabled;

    private Vector3 _currentRotation;

    [SerializeField]
    private Transform _lookAtTarget;

	float _origY;

    Vector3 _playerControlledScale = new Vector3(2.25f, 2.25f, 2.25f);

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

    public void SetMouseEnabled (bool enabled) {
        _mouseEnabled = enabled;
    }
    	
    void Start() {
        PlayerControlled(true, null);
		_origY = transform.position.y;
        _mouseEnabled = false;
    }

	// Update is called once per frame
	void Update () {
        if (_mouseEnabled) {
            ManageMouseMovement();
        }
        ManageCameraPosition();
        ManageCameraZoom();
	}

    void ManageMouseMovement() {

        // THIS IS FOR TESTING PURPOSES
        // START HERE
        /*
		if (Input.GetKeyDown(KeyCode.F1)) {
            StopViewingObject();
        }
		*/
        // END TEST

        if (_playerControlled) { 
            if (_objectOfInterest == null) { 
                _inputX = Input.GetAxis("Mouse X");
                _inputY = Input.GetAxis("Mouse Y");
                _inputY = -_inputY;

				float yAxisConstraint = transform.localEulerAngles.x + _inputY * _cameraRotationSpeed;
				if((yAxisConstraint > 75f && yAxisConstraint < 180f) || (yAxisConstraint < 285f && yAxisConstraint >= 180f)) {
					_inputY = 0f;
				}
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
                _mainCamera.rotation = Quaternion.Lerp(_mainCamera.rotation, _lookAtTarget.rotation, Time.deltaTime * _cameraRotationSpeed);
                _continueRotate = true;
            }
        }

        //if (Input.GetMouseButtonDown(0)) {
        //    PlayerControlled(true, null);
        //    _objectOfInterest = null;
        //}
    }

    void ManageCameraPosition() {
        if (_lookAtTarget != null) { 
            transform.position = Vector3.Slerp(transform.position, _lookAtTarget.position, Time.deltaTime * _cameraMoveSpeed/4);
            _mainCamera.localPosition = Vector3.Lerp(_mainCamera.localPosition, Vector3.zero, 0.1f);
            transform.localScale = Vector3.Slerp(transform.localScale, Vector3.one, 0.1f);
        }
        else {
            // have camera point above the player
            Vector3 p = _playerObject.transform.position;
            p.y = _origY;

            float amount = Time.deltaTime * _cameraMoveSpeed;
            amount = _playerObject.GetComponent<PlayerControllerTest>().enabled ? amount : amount / 4f;

            transform.position = Vector3.MoveTowards(transform.position, p, amount);
            if (SceneManager.GetActiveScene().name.Equals("4. Room")) {
                Vector3 originalMainCameraLocalPosition = new Vector3(0f, -4f, -10f);
                _mainCamera.localPosition = Vector3.Lerp(_mainCamera.localPosition, originalMainCameraLocalPosition, 0.1f);
                transform.localScale = Vector3.Lerp(transform.localScale, _playerControlledScale / 2f, 0.1f);
            } else {
                Vector3 originalMainCameraLocalPosition = new Vector3(0f, 0f, -10f);
                _mainCamera.localPosition = Vector3.Lerp(_mainCamera.localPosition, originalMainCameraLocalPosition, 0.1f);
                transform.localScale = Vector3.Lerp(transform.localScale, _playerControlledScale, 0.1f);
            }
            
        }
    }

    void ManageCameraZoom() {

        float MouseScrollAmount = Input.GetAxis("Mouse ScrollWheel");

        if (MouseScrollAmount != 0)
		{
            Vector3 newScale = transform.localScale;
			newScale -= new Vector3(1f, 1f, 1f) * Mathf.Clamp (MouseScrollAmount, _zoomLimit.Min, _zoomLimit.Max) * transform.localScale.x;
            transform.localScale = Vector3.Slerp(transform.localScale, newScale, Time.deltaTime * _scrollSpeed);
        }
    }
}
