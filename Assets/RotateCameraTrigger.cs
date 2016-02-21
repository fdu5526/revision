using UnityEngine;
using System.Collections;

public class RotateCameraTrigger : MonoBehaviour {

    [SerializeField]
    private CameraControlScript _camera;
    [SerializeField]
    private Transform _lookAtTarget;

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            _camera.PlayerControlled(false, _lookAtTarget);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _camera.PlayerControlled(true, null);
        }
    }
}
