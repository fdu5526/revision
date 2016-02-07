using UnityEngine;
using System.Collections;

public class rotationMechanic : Ability {
	public enum rotationType {horizontal, vertical};
	public float turnDirection = 1;
	public rotationType rotationOrientation;
	public float angleOfRotation;
	public bool turned = false;

	// Use this for initialization
	void Start () {
		//toggleRotation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Activate()
    {
        toggleRotation();
    }


    public void toggleRotation(){

		if(GameButtonMaster.ready){
			turned = !turned;
			powerTracker.power[1] = turned;
			StartCoroutine(turnTheObject(turned));
		}
	}

	public IEnumerator turnTheObject(bool toggleRotation){
		Debug.Log("Hi!");


			float counter = 0;
			float unrotatedModified = 1f;
			if(toggleRotation == false){
				//Debug.Log("Modifier to -1");
				unrotatedModified = -1f;
			}

			while(counter < angleOfRotation){

				if(rotationOrientation == rotationType.horizontal){
				//Debug.Log("turning direction is:" +turnDirection*unrotatedModified);
					transform.Rotate(0, (turnDirection*unrotatedModified), 0);
					GameButtonMaster.ready = false;
				}
				if(rotationOrientation == rotationType.vertical){
				transform.Rotate( (turnDirection*unrotatedModified), 0,0);
					GameButtonMaster.ready = false;
				}
				counter++;

				if(counter >= angleOfRotation){
					GameButtonMaster.ready = true;
					if(!toggleRotation){
						Vector3 originalRotation = new Vector3(0, 0, 0);
						transform.eulerAngles = originalRotation;
					}
				}

				yield return null;
			}

			

			}
	}

	/*	if(rotationOrientation == rotationType.vertical){
				while(transform.rotation.eulerAngles.x < angleOfRotation){
					transform.Rotate(0, (1*turnDirection), 0);
					GameButtonMaster.ready = false;
					yield return null;
				}
				GameButtonMaster.ready = true;
			}
		}
		
		if(toggleRotation==false){
			if(rotationOrientation == rotationType.horizontal){
				while(transform.rotation.eulerAngles.y > 0){
					transform.Rotate(0, -1, 0);
					if(transform.rotation.eulerAngles.y < 5f){
						Vector3 copyOfRotation = transform.rotation.eulerAngles;
						copyOfRotation.y = 0;
						transform.eulerAngles = copyOfRotation;
					}
					GameButtonMaster.ready = false;
					yield return null;
				}
				GameButtonMaster.ready = true;
			}

			if(rotationOrientation == rotationType.vertical){
				while(transform.rotation.eulerAngles.x > 0){
					transform.Rotate(-1, 0, 0);
					if(transform.rotation.eulerAngles.y < 5f){
						Vector3 copyOfRotation = transform.rotation.eulerAngles;
						copyOfRotation.y = 0;
						transform.eulerAngles = copyOfRotation;
					}
					GameButtonMaster.ready = false;
					yield return null;
				}
				GameButtonMaster.ready = true;
			}
		}*/
		//GameButtonMaster.ready = false;
	

