using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour {

    //Attributes
    private EnemyManager enemyManager;
    public GameObject gameOverScreen;
	public Slider healthBar;
	public int maxHealth;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }
    private int health;

	// Use this for initialization
	void Start ()
    {
		health = maxHealth;
		healthBar.maxValue = maxHealth;
		//we should make enemy manager a singleton
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		healthBar.value = health;
	}

	//Triggers when the Plyaer runs into an enemy (doesn't trigger when an enemy runs into the player)
	void OnControllerColliderHit(ControllerColliderHit col)
    {
        //Destroy enemy on collision /w/ Player (for now) and reduce a random spawn's counter by 1
        if (col.gameObject.tag == "Enemy")
        {
			Debug.Log("hit");
			EnemyController controller = col.gameObject.GetComponent<EnemyController>();
			if (controller != null)
			{
				CollideWithEnemy(controller);
				//controller.Die();
			}
			else
			{
				Destroy(col.gameObject);
				enemyManager.enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
			}
        }
    }

	// if we add more enemy tips we can handle different forms of collision here
	public void CollideWithEnemy(EnemyController enemy)
	{
		health -= 10;
		enemy.Die();

        //Kill the Player if out of health
        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
            gameOverScreen.GetComponentInChildren<Text>().text = "Score: " + this.GetComponent<ScoreManager>().score;
        }
	}
}
