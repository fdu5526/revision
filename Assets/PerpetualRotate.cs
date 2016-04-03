using UnityEngine;
using System.Collections;

public class PerpetualRotate : MonoBehaviour {

    private enum RotateAxis {
        X,
        Y,
        Z
    }

    [SerializeField]
    private RotateAxis _rotateAxis;
    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    switch (_rotateAxis) {
            case RotateAxis.X:
                transform.Rotate(new Vector3(1f, 0f, 0f) * _speed);
                break;
            case RotateAxis.Y:
                transform.Rotate(new Vector3(0f, 1f, 0f) * _speed);
                break;
            case RotateAxis.Z:
                transform.Rotate(new Vector3(0f, 0f, 1f) * _speed);
                break;
        }
	}
}
