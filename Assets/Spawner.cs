using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float minRateOfSpawn;
    public float maxRateOfSpawn;
    float spawnRate;

    public bool fixedRate;
    public float increaseRate;

    public GameObject spawn;
    // Use this for initialization
    void Start()
    {
        spawnRate = (float)Random.Range(minRateOfSpawn, maxRateOfSpawn);
        //Debug.Log("Spawnrate is: "+spawnRate);
        StartCoroutine(spawning());
    }

    void Spawn()
    {
        //Debug.Log("Spawning a "+spawn.name);
        GameObject newGO = Instantiate(spawn, transform.position, transform.rotation) as GameObject;
    }

    IEnumerator spawning()
    {

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Spawn();
            if (!fixedRate) {
                spawnRate *= increaseRate;
                //Debug.Log("New spawnrate is: " + spawnRate); 
            }
            if (spawnRate < minRateOfSpawn)
            {
                spawnRate = minRateOfSpawn;
            }
        }

    }
}
