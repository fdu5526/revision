using UnityEngine;
using System.Collections;

public class RotateCameraTrigger : MonoBehaviour {

    [SerializeField]
    private CameraControlScript _camera;
    [SerializeField]
    private Transform _lookAtTarget;
    [SerializeField]
    private Transform _objectOfInterest;

	void OnTriggerEnter(Collider other) {
		//print("something triggered");
		if (other.tag == "Player") {
			print("its a player");
            _camera.PlayerControlled(false, _lookAtTarget);
			other.GetComponent<PlayerControllerTest>().DisableMovement();
            //_camera.SetObjectOfInterest(_objectOfInterest);
        }
    }

	public void stare(){
		GameObject.FindObjectOfType<PlayerControllerTest> ().DisableMovement ();
		_camera.PlayerControlled(false, _lookAtTarget);
	}
}
