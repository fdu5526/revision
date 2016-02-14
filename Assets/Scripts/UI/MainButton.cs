using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public class MainButton : MonoBehaviour {

    private Animator _anim;
	private bool toggle = false;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}
	
	public void AnimateButtonSpread() {
        _anim.Play("SpreadAnimation");
    }

    public void AnimateButtonShrink() {
        _anim.Play("UnSpreadAnim");
    }

    /*
	public void ToggleAnimationOff(){
		if(toggle){
			AnimateButtonShrink();
			toggle = false;
			Debug.Log("Toggle is set to "+toggle);
		}
	}

	public void ToggleAnimationOn(){
		if(toggle == false){
			AnimateButtonSpread();
			toggle = true;
			Debug.Log("Toggle is set to "+toggle);
		}
	}
    */

    public void ToggleAnimation()
    {
        toggle = !toggle;
        Log.Metrics.Message("MainButton-" + (toggle ? "on" : "off"));
        if (toggle)
        {
            AnimateButtonSpread();
        }
        if (toggle==false)
        {
            AnimateButtonShrink();
        }
    }
}