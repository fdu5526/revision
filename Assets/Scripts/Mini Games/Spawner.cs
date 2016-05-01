using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float minRateOfSpawn;
    public float maxRateOfSpawn;
    float spawnRate;

    public bool fixedRate;
    public float increaseRate;

	public bool onlyOnTrigger = false;

    public GameObject spawn;
    
    // Use this for initialization
    void Start()
    {
        spawnRate = (float)Random.Range(minRateOfSpawn, maxRateOfSpawn);
        //Debug.Log("Spawnrate is: "+spawnRate);
		if(onlyOnTrigger==false){StartCoroutine(spawning());}
    }

    public void Spawn()
    {
        //Debug.Log("Spawning a "+spawn.name);
		if(DebugSwitch.debugMode == false){
        	GameObject newGO = Instantiate(spawn, transform.position, transform.rotation) as GameObject;
		}
    }

    IEnumerator spawning()
    {

        while (true)
        {
            
            Spawn();
            if (!fixedRate) {
                spawnRate *= increaseRate;
                //Debug.Log("New spawnrate is: " + spawnRate); 
            }
            if (spawnRate < minRateOfSpawn)
            {
                spawnRate = minRateOfSpawn;
            }
			yield return new WaitForSeconds(spawnRate);
        }

    }
}
