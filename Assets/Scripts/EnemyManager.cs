using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<SpawnEnemies> enemySpawns;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RegisterDeath()
    {
        enemySpawns[Random.Range(0, enemySpawns.Count)].spawnedEnemies -= 1;
    }
}
