using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

	public float speed = 2f;
	public bool xAxisMovementEnabled = true;
	public bool zAxisMovementEnabled = false;
	public bool yAxisMovementEnabled = false;
	public bool jumpEnabled = false;
	public float jumpForce;
	public int jumpDelay=30;
	public int jumpCounter =0;
    public bool paused=false;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        if (paused == false)
        {
            checkMovement();
        }
		if(jumpCounter>0){
			jumpCounter--;
		}
	}

	void turn (float targetAngle)
	{
		if (transform.eulerAngles.y != targetAngle) {
			Vector3 tempVector = new Vector3 (transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
			transform.eulerAngles = tempVector;
		}
	}

	void checkMovement ()
	{

		if (xAxisMovementEnabled) {
			if (Input.GetKey (KeyCode.D)) {
				turn (90f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
			}
		
			if (Input.GetKey (KeyCode.A)) {
				turn (270f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
			}
		}

		if (zAxisMovementEnabled) {
			if (Input.GetKey (KeyCode.W)) {
				turn (0f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
			}
		
			if (Input.GetKey (KeyCode.S)) {
				turn (180f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
			}
		}

		if(yAxisMovementEnabled){
			if (Input.GetKey (KeyCode.UpArrow)) {
				turn (0f);
				transform.Translate (Vector3.up * (speed * Time.deltaTime));
			}
			
			if (Input.GetKey (KeyCode.DownArrow)) {
				turn (180f);
				transform.Translate (Vector3.down * (speed * Time.deltaTime));
			}
		}

		if(jumpEnabled){
			if (Input.GetKeyDown(KeyCode.Space) && jumpCounter <1){
//				Debug.Log("jumping");
				//transform.Translate (Vector3.up * (jumpHeight));
				//GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpForce));
				jumpCounter = jumpDelay;
			}
			if(jumpCounter > jumpDelay/2){
				transform.Translate (Vector3.up*(.5f));
			}
		}

	}

}
