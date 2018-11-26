using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {

    //Target Attributes
	private CharacterController characterController;
	// once we have more code for the player we might change this
	private GameObject target;
	//the enemies health
	private int health;

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
	
	//The enemies max health
	public int maxHealth;

    //Speed Controller
	public float maxSpeed;


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}

	void OnEnable()
	{
		// this is temporary, im pretty sure calling find is expensive in terms of processing, will do this another way later
		target = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
		// this is also temporary, in future will make this more fleshed out
        //Move toward the target
		Vector3 toTarget = target.transform.position - this.transform.position;
		Vector3 desiredVelocity = toTarget.normalized * maxSpeed;
		if (!characterController.isGrounded)
		{
			desiredVelocity += Physics.gravity;
		}
		characterController.Move(desiredVelocity *Time.deltaTime);

        //Kill self if I fall off the edge of the map
        if (transform.position.y < -30)
            Die();
	}

    //Take Damage
	public void Damage(int damage)
	{
		health -= damage;
		if(health <= 0)
		{
			Die();
		}
	}

    //Destroy Self. Triggered when health <= 0 or colliding /w/ Player
	public void Die()
	{
        //If this unit is killed by having its health reduced, increase score
        if (health <= 0)
        {
            target.GetComponent<ScoreManager>().score += 1;
            target.GetComponent<ScoreManager>().UpdateScore();
        }
		EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		Object.Destroy(gameObject);
		manager.enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
	}

    //Collision /w/ Player
	void OnControllerColliderHit(ControllerColliderHit col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerCollisions>().CollideWithEnemy(this);
		}
	}
}
