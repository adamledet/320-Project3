using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //Pause Variable
    private bool isPaused;
    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
    public GameObject pauseScreen;


    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
		health = maxHealth;
		healthBar.maxValue = maxHealth;
		//we should make enemy manager a singleton
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		healthBar.value = health;

        //After falling off the stage, take damage and reset position
        if(transform.position.y <= -30)
        {
            health -= 10;
            transform.position = new Vector3(0, 2, 0);
            if (health <= 0)
                TriggerGameOver();
        }

        //P button works as Pause or Restart
        if (Input.GetKeyDown("escape"))
        {
            //Pause / Unpause while alive
            if(health > 0)
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    pauseScreen.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    pauseScreen.SetActive(false);
                    Time.timeScale = 1;
                }
            }

            //Restart while dead
            else if(gameOverScreen.activeSelf)
            {
                SceneManager.LoadScene("Game");
            }
        }

        //Exit to Main Menu if game is Paused or if Game Over
        if ((Input.GetKeyDown("q") && isPaused) || (gameOverScreen.activeSelf && Input.GetKeyDown("q")))
        {
            SceneManager.LoadScene("TitleScreen");
        }
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
				CollideWithEnemy(controller);
				//controller.Die();
			}
			else
			{
				Destroy(col.gameObject);
                //enemyManager.enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
                enemyManager.RegisterDeath();
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
            TriggerGameOver();
	}

    //
    void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponentInChildren<Text>().text = "Score: " + this.GetComponent<ScoreManager>().score;
        Time.timeScale = 0;
    }
}
