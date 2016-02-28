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
        if (other.tag == "Player") {
            _camera.PlayerControlled(false, _lookAtTarget);
            //_camera.SetObjectOfInterest(_objectOfInterest);
        }
    }
}
