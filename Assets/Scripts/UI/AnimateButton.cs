using UnityEngine;
using System.Collections;

public class AnimateButton : MonoBehaviour {

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}
	
	public void PlayAnimation() {
        _anim.Play("LOOP");
    }
}
