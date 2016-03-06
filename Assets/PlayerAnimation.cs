using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    private bool _setTalking;
    private bool _setWalking;
    private bool _setRunning;

    private Animator _animator;

    [SerializeField]
    private float _runVelocityThreshold;
    [SerializeField]
    private float _walkVelocityThreshold;


    [SerializeField]
    private PlayerControllerTest _playerController;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (_walkVelocityThreshold < _playerController.ReturnVelocity() && _runVelocityThreshold > _playerController.ReturnVelocity()) {
            _animator.Play("animation_steve_walktest1");
        }
        // Place the run animation here - when the velocity gets past a certain threshold, go and run
        else if (_runVelocityThreshold < _playerController.ReturnVelocity()){
            _animator.Play("animation_steve_walktest1");
        }
        else{
            _animator.Play("animation_steve_onewave");
        }
	}
}
