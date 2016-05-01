using UnityEngine;
using System.Collections;

public class initializeWord : MonoBehaviour {

    TextMesh myMesh;
    GameObject myDictionary;
    Vector3 target;
    
	public bool translated;
    public float speed;
    Vector3 myPosition;
    public bool paused=false;
    translatedWord myWord;


	// Use this for initialization
	void Start () {
        myMesh = GetComponent<TextMesh>();
        myDictionary = FindObjectOfType<Dictionary>().gameObject;
        myPosition = transform.position;
        target = GameObject.Find("Target").transform.position;


        translated = false;

        float tempFloat = myDictionary.GetComponent<Dictionary>().word.Length;
        int tempInt = (int)Random.Range(0,tempFloat-1);
        myWord = myDictionary.GetComponent<Dictionary>().word[tempInt];
        myMesh.text = myWord.english;
    }

    void Update()
    {
        if (paused == false) {
            move();
        }
    }

    void move()
    {
        myPosition = Vector3.MoveTowards(myPosition, target, speed);
        transform.position = myPosition;
    }

	/*
    IEnumerator translate()
    {
        translated = true;
        paused = true;
        myMesh.text = "";
        movement.paused = true;
        yield return new WaitForSeconds(2);
        
        paused = false;
        myMesh.text = myWord.korean;
        movement.paused = false;
    }
*/
	/*
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Triggered! Other object's name is: "+other.name);
        if (other.gameObject.name == "Target")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Player"&&translated==false)
        {
            StartCoroutine(translate());
        }
    }
	*/
}
