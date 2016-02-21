using UnityEngine;
using System.Collections;

public class AnimationTrigger : MonoBehaviour {
	public GameObject target;
	public string nameOfAnimation;
	// Use this for initialization
	void Start () {
		target.GetComponent<Animator>().Play(nameOfAnimation);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
