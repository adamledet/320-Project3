using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    //Attributes
    public GameObject enemy;
    public int enemyCap;
    public float spawnRate;
    public int spawnedEnemies;

    //Out of 10, what percentage of the time will an enemy spawn once the Counter is reached?
    public int spawnChance;

    private float spawnCounter;

	// Use this for initialization
	void Start ()
    {
        spawnedEnemies = 0;
        spawnCounter = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Check if the spawner has room to spawn another enemy
		if(spawnedEnemies < enemyCap)
        {
            //Incriment counter
            spawnCounter += .1f;

            //If counter exceds threshhold, yield a chance to spawn an enemy
            if (spawnCounter > spawnRate)
                if (Random.Range(0, 10) >= spawnChance)
                {
                    Spawn(enemy);
                    spawnCounter = 0;
                }
                else
                    spawnCounter -= Random.Range(0, spawnCounter);//If an enemy isn't spawned, reduce the counter
        }
	}

    //Spawn a new enemy of a certain type
    void Spawn(GameObject unit)
    {
        float xOffset = Random.Range(-4, 4);
        float zOffset = Random.Range(-4, 4);
        Instantiate(unit, new Vector3(transform.position.x + xOffset, transform.position.y + 5, transform.position.z + zOffset), Quaternion.identity);
        spawnedEnemies += 1;
    }
}
