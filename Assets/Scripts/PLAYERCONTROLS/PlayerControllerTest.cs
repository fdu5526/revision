using UnityEngine;
using System.Collections;

public class PlayerControllerTest : MonoBehaviour {

    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private float _moveSpeed;

    private float _moveForward;
    private float _moveSide;
	public static bool movementEnabled = true;
    private float _velocity;

    private Vector3 _forwardPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(movementEnabled){
			ManageMovement();
        	ManageRotation();
		}
    }

    public float ReturnVelocity() {
        return _velocity;
    }

    void ManageMovement() {
        _forwardPosition = _camera.transform.forward;
        _moveForward = Input.GetAxis("Vertical");
        _moveSide = Input.GetAxis("Horizontal");

        transform.position += ((_camera.transform.forward * _moveForward) + (_camera.transform.right *_moveSide)) *_moveSpeed;

        _velocity = (((_camera.transform.forward * _moveForward) + (_camera.transform.right * _moveSide)) * _moveSpeed).magnitude;
    }

    void ManageRotation() {
        
        // Horizontal Facing
        if (_moveForward == 0) { 
            if (_moveSide < 0)
            {
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 0f, 0f));
            }
            else if (_moveSide > 0){
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 180f, 0f));
            }
        }

        // Vertical Facing && Diagonal Facing
        if (_moveForward < 0)
        {
            if (_moveSide ==  0) { 
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 270f, 0f));
            }
            else if (_moveSide > 0)
            {
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 225f, 0f));
            }
            else if (_moveSide < 0)
            {
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 315f, 0f));
            }
        }
        else if (_moveForward > 0)
        {
            if (_moveSide == 0) { 
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 90f, 0f));
            }

            else if (_moveSide > 0)
            {
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 135f, 0f));
            }

            else if (_moveSide < 0)
            {
                transform.rotation = Quaternion.Euler(_camera.transform.localEulerAngles + new Vector3(0f, 45f, 0f));
            }
        }



    }
}
