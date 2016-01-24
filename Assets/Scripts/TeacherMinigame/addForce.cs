using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class addForce : MonoBehaviour {

	Rigidbody myBody;
	public float baseX;
	public float baseY;

	public float variableX;
	public float variableY;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody>();
		variableY = (float)Random.Range(-variableY,variableY);
		variableX = (float)Random.Range(-variableX,variableX);
		myBody.AddForce(baseX+variableX,baseY+variableY,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
