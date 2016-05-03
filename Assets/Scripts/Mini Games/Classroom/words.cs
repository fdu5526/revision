using UnityEngine;
using System.Collections;

public class words : MonoBehaviour {
	
	TextMesh myMesh;
	GameObject myDictionary;
	Vector3 target;

	public float speed;
	Vector3 myPosition;

	translatedWord myWord;
	AudioSource whining;

	// Use this for initialization
	void Start () {
		whining = GameObject.Find ("WHINEAUDIO").GetComponent<AudioSource>();
		myMesh = GetComponent<TextMesh>();
		//myAudio = GetComponent<AudioSource> ();
		myDictionary = FindObjectOfType<Dictionary>().gameObject;
		myPosition = transform.position;

        if (target == null) { 
            target = GameObject.FindGameObjectWithTag("Target").transform.position;
        }
		//target = GameObject.Find("Target").transform.position;


		float tempFloat = myDictionary.GetComponent<Dictionary>().word.Length;
		int tempInt = (int)Random.Range(0,tempFloat-1);
		myWord = myDictionary.GetComponent<Dictionary>().word[tempInt];
		myMesh.text = myWord.english;

		// resize the collider to the size of the text
		MeshRenderer mr = GetComponent<MeshRenderer>();
		GetComponent<BoxCollider>().size = new Vector3(mr.bounds.extents.x * 2f + 0.4f, 2f, 1f);
		transform.Find("Background").localScale = new Vector3(mr.bounds.extents.x * 2f + 0.4f, 2f, 1f);
	}

    public void SetTarget(Transform newTarget) {
        target = newTarget.position;
    }

	void Update()
	{
		if(DebugSwitch.debugMode == false){
			move();
		}
	}

	void move()
	{
		//Debug.Log("Moving towards: ");
		myPosition = Vector3.MoveTowards(myPosition, target, speed);
		transform.position = myPosition;
	}

	void OnMouseDown() {
		if(DebugSwitch.debugMode== false && TranslateMaster.pause ==false){
			whining.Play ();
			TranslateMaster.pause = true;
			TranslateMaster tempGO = GameObject.FindObjectOfType<TranslateMaster>();
			tempGO.activatePanel(myWord.english);

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		print ("I'm colliding with something! It's tag is: "+other.tag);
		if (other.gameObject.tag == "Target")
		{
			//print ("In the destroy loopy part");
			Destroy(gameObject);
		}
	}
}
