﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour {

    //Attributes
    EnemyManager enemyManager;

    // Use this for initialization
    void Start ()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    //Triggers when the Enemy runs into the Player (doesn't trigger when an enemy runs into the player)
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        //Destroy enemy on collision /w/ Player (for now) and reduce a random spawn's counter by 1
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            enemyManager.RegisterDeath();
            //enemyManager.GetComponent<EnemyManager>().enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
        }
    }
}
