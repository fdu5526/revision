using UnityEngine;
using System.Collections;

public class momMovement : MonoBehaviour {
	public Transform destination;
	public Transform origin;
	public bool paused = false;
	public float speed = .5f;
	public Spawner spawnPoint;
	public int narrativeCounter=0;
	public int speedIncrement = 3;
	public GameObject[] flowcharts;
	public NodeManager theNodeManager;
	// Use this for initialization
	void Start () {
		theNodeManager = GameObject.FindObjectOfType<NodeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (paused == false && destination !=null) {
			transform.position = Vector3.MoveTowards (transform.position, destination.position, speed);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Obstacle"){
			print ("should switch destination");
			destination = origin;
			theNodeManager.updatePairs ();
		}

		if (other.tag == "TriggerArea") {
			//StartCoroutine (pauseFor (3));
			if (flowcharts.Length > narrativeCounter) {
				togglePause ();
				flowcharts [narrativeCounter].SetActive (true);
				narrativeCounter++;
				spawnPoint.Spawn ();
				speed *= speedIncrement;
				speedIncrement--;
				if (speedIncrement == 0) {
					speedIncrement = 1;
				}
			}
		}
	}

	public void togglePause(){
		paused = !paused;
	}

	IEnumerator pauseFor(int seconds){
		paused = true;
		yield return new WaitForSeconds(seconds);
		paused = false;
	}
}
