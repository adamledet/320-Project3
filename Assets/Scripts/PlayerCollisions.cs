using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    //Attributes
    EnemyManager enemyManager;

	// Use this for initialization
	void Start ()
    {
		//we should make enemy manager a singleton
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    //Triggers when the Plyaer runs into an enemy (doesn't trigger when an enemy runs into the player)
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        //Destroy enemy on collision /w/ Player (for now) and reduce a random spawn's counter by 1
        if (col.gameObject.tag == "Enemy")
        {
			EnemyController controller = col.gameObject.GetComponent<EnemyController>();
			if (controller != null)
			{
				controller.Die();
			}
			else
			{
				Destroy(col.gameObject);
				enemyManager.enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
			}
        }
    }
}
