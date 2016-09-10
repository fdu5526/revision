using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

	//This should be used ONLY for the Teacher scene

	public float speed = 2f;
	public bool xAxisMovementEnabled = true;
	public bool zAxisMovementEnabled = false;
	public bool yAxisMovementEnabled = false;
	public bool jumpEnabled = false;
	public float jumpForce;
	public int jumpDelay=30;
	public int jumpCounter =0;
    public bool paused=false;
	bool resetToggled = false;
	Animator myanimator;

	// Use this for initialization
	void Start ()
	{
		myanimator = GetComponent<Animator> ();
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

	public void DisableMovement () {
		GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().useGravity = false; 	
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
		//print("Checking movement");
		//check if Steve is upright
		/*if(transform.rotation.y != 270){
			print("I'm off center");
			resetToggled = true;
			Invoke("ResetPosition", 1);
		}*/

		if (xAxisMovementEnabled) {
			if (Input.GetKey (KeyCode.RightArrow) ||
					Input.GetKey (KeyCode.D)) {
				//turn (90f);
				//transform.Translate (Vector3.forward * (speed * Time.deltaTime));
				transform.Translate (Vector3.back * (speed * Time.deltaTime));
				if (myanimator.GetBool ("runRight") == false) {					
					myanimator.SetBool ("runRight", true);
				}

			}
		
			if (Input.GetKey (KeyCode.LeftArrow) ||
					Input.GetKey (KeyCode.A)) {
				//turn (270f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
				if (myanimator.GetBool ("runLeft") == false) {					
					myanimator.SetBool ("runLeft", true);
				}
			}

			if (Input.GetKeyUp (KeyCode.RightArrow) ||
				Input.GetKeyUp (KeyCode.D)) {
				//turn (90f);
				//transform.Translate (Vector3.forward * (speed * Time.deltaTime));
				transform.Translate (Vector3.back * (speed * Time.deltaTime));
				if (myanimator.GetBool ("runRight") == true) {					
					myanimator.SetBool ("runRight", false);
				}

			}

			if (Input.GetKeyUp (KeyCode.LeftArrow) ||
				Input.GetKeyUp (KeyCode.A)) {
				//turn (270f);
				transform.Translate (Vector3.forward * (speed * Time.deltaTime));
				if (myanimator.GetBool ("runLeft") == true) {					
					myanimator.SetBool ("runLeft", false);
				}
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
	public void SetPause (bool paused) {
		this.paused = paused;
	}
	public void togglePause(){
		paused = !paused;
	}

	void OnCollisionEnter(Collision other){
		print("I collided");
		if(other.collider.tag=="Letter" && resetToggled == false){
			GetComponent<Rigidbody> ().isKinematic = false;
			myanimator.SetTrigger ("ouch");
			GetComponent<AudioSource> ().Play ();
			print("I collided with a Letter and I'm gonnna reset");
			resetToggled = true;
			paused = true;
			Invoke("ResetPosition", 1);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Target") {
			togglePause ();
		}
	}

	void ResetPosition(){		
		//cameraSettingToggle myCamera = GameObject.FindObjectOfType<cameraSettingToggle>();
		//myCamera.resetPositionInstantaneous();
		//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		//gameObject.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
		//gameObject.GetComponent<Rigidbody>().Sleep();
		paused = false;
		resetToggled = false;

	}
}
