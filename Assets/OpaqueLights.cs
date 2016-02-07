using UnityEngine;
using System.Collections;

public class OpaqueLights : MonoBehaviour 
{
	private Renderer john; //john is your 3D objects renderer, he is your friend.
	private Color color;
	public float speed = .1f;
	float alpha = 0f;

	void Start () 
	{
		john = this.GetComponent<Renderer>(); 
		color = john.material.color;
	}

	void Update () 
	{
		alpha += (speed * Time.deltaTime);

		if (alpha >= 1)
		{
			alpha = 0;
		}
		color.a = alpha; 
	}
}
