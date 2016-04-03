using UnityEngine;
using System.Collections;

public class FollowCameraPivot : MonoBehaviour {

    [SerializeField]
    private GameObject _cameraPivot;
    [SerializeField]
    private GameObject _player;

	void Update () {
        Quaternion dummyRotation = _cameraPivot.transform.rotation;
        dummyRotation.x = 0;
        dummyRotation.z = 0;
        transform.rotation = dummyRotation;
        transform.position = _player.transform.position;
        
	}
}
