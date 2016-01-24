using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallGrowScript : MonoBehaviour {

    [SerializeField]
    GameObject _slider;

	// Use this for initialization
	void Start () {
        _slider.GetComponent<Slider>().value = 3;
    }

    void Update() {
        float growVal = _slider.GetComponent<Slider>().value;
        
        transform.localScale = new Vector3(growVal, growVal, growVal);
    }
	
	public void Grow() {
        transform.localScale += new Vector3(1f, 1f, 1f);
    }

    public void Shrink() {
        transform.localScale -= new Vector3(1f, 1f, 1f);
    }

    public void SliderGrow() {

    }
}
