using UnityEngine;
using System.Collections;

public class friendMovement : MonoBehaviour {
    public bool pickedUp = false;
	public string defaultResponse;
    public float snapDistance = 2f;
    public TextMesh speechBubble;

    public relationship[] relationships;

    GameObject nearestObject;
	FriendsMaster masterObject;
    public Vector3 originalPosition;
	bubbleResize speechResizeScript;
	bool moving = false;
    [SerializeField] SpriteRenderer _tail;
	// Use this for initialization
	void Start () {
		speechResizeScript = gameObject.GetComponentInChildren<bubbleResize> ();

        speechBubble.text = "";
		masterObject = GameObject.FindObjectOfType<FriendsMaster>();
		_tail.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (pickedUp)
        {
            followMouse();
        }
	}

	public void turnOffTail(){
		_tail.enabled = false;
	}

    void OnMouseDown()
    {
		if(DebugSwitch.debugMode == false && moving == false)
		{
        Debug.Log("picked up");
        pickedUp = true;
			if (nearestObject != null && nearestObject.GetComponent<friendSpot>().occupant == gameObject)
        	{
			//print (nearestObject.name+" is set to null because you picked me up.");
            nearestObject.GetComponent<friendSpot>().occupant = null;
        	}
		}
		if (DebugSwitch.debugMode) {
			print ("In debug!");
		}

		if (moving) {
			print ("still moving");
		}

    }

    void OnMouseUp()
    {
        Debug.Log("put down");
        pickedUp = false;
        snapToPosition();
    }

    void followMouse()
    {
        Vector3 tempvector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tempvector.z = transform.position.z;
        transform.position = tempvector;
    }

    void snapToPosition()
    {
        findNearest();
        float distanceToNearestObject = Vector3.Distance(transform.position, nearestObject.transform.position);
		if (distanceToNearestObject < snapDistance && nearestObject.GetComponent<friendSpot>().occupant == null)
        {
			//setInSpot ();
			transform.position = nearestObject.transform.position;
			//print (nearestObject.name+" set to me because snap to position");
			nearestObject.GetComponent<friendSpot>().occupant = gameObject;
            nearestObject.GetComponent<friendSpot>().checkOthers();
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    public void reactTo(string newcomer)
    {
		if(FriendsMaster.debugged){
        for(int i = 0; i < relationships.Length; i++)
        {
            if (newcomer == relationships[i].name)
            {
                //speechBubble.text = relationships[i].opinion;
                StartCoroutine(flashText(relationships[i].opinion));
                if(relationships[i].like == false)
                {
                    leave();
                }
            }
        }
			masterObject.checkWin();
		}

		else{
			StartCoroutine(flashText(defaultResponse));
			masterObject.checkWin();
		}
    }

    IEnumerator flashText(string tempText)
    {
        speechBubble.text = tempText;
        _tail.enabled = true;
		resizeSpeech ();
        yield return new WaitForSeconds(2f);
        speechBubble.text = "";
        _tail.enabled = false;
		resizeSpeech ();
    }

    IEnumerator move(Vector3 target)
    {
		moving = true;
        float distanceToTarget = Vector3.Distance(transform.position, target);
        yield return new WaitForSeconds(.5f);
        while (distanceToTarget>.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 1f*Time.deltaTime);
            distanceToTarget = Vector3.Distance(transform.position, target);
            if (distanceToTarget < .5f)
            {
                transform.position = target;
                distanceToTarget = 0;
				moving = false;
            }
            yield return null;
        }
        yield return null;
    }

    public void leave()
    {
		if(nearestObject != null){
			//print (nearestObject.name + " set to null because leave");
		nearestObject.GetComponent<friendSpot>().occupant = null;
		}
        //transform.position = originalPosition;
        StartCoroutine(move(originalPosition));
    }

    void findNearest()
    {
        GameObject[] spots = GameObject.FindGameObjectsWithTag("Spot");
        //Debug.Log("Found "+spots.Length+" spots");
        

		nearestObject = spots[0];
        for(int i = 1; i < spots.Length; i++)
        {
            float distanceToNearestObject = Vector3.Distance(transform.position, nearestObject.transform.position);
            float distanceToCurrentObject = Vector3.Distance(transform.position, spots[i].transform.position);
            if(distanceToNearestObject > distanceToCurrentObject && spots[i].GetComponent<friendSpot>().occupant == null)
            {
                nearestObject = spots[i];
            }
        }
    }
	//Calls function in bubbleResize.cs that resizes the speech bubble
	//Used to detect when speech changes
	void resizeSpeech()
	{
		if (speechResizeScript != null) {
			speechResizeScript.resizeBubs ();
		}
	}
}
