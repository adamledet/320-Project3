using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {

    //Target Attributes
	private CharacterController characterController;
	private NavMeshAgent navAgent;
	// once we have more code for the player we might change this
	private GameObject target;
    private Animator animator;
    private bool dying;

    public bool Dying
    {
        get
        {
            return dying;
        }
    }
	//the enemies health
	private int health;

	private Vector3 KnockBack;

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
	void Start ()
    {
        health = 1;
		KnockBack = Vector3.zero;
		characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
		navAgent.updatePosition = false;
		navAgent.updateRotation = true;
		navAgent.speed = maxSpeed;
        dying = false;
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
        if (!dying)
        {
            if (KnockBack.magnitude > 0.2)
            {
                characterController.Move(KnockBack * Time.deltaTime);
                KnockBack = Vector3.Lerp(KnockBack, Vector3.zero, 5 * Time.deltaTime);
            }
            else
            {
                //Vector3 toTarget = target.transform.position - this.transform.position;
                //Vector3 desiredVelocity = toTarget.normalized * maxSpeed;
                navAgent.destination = target.transform.position;
                Vector3 desiredVelocity = navAgent.desiredVelocity;
                if (!characterController.isGrounded)
                {
                    desiredVelocity += Physics.gravity;
                }
                characterController.Move(desiredVelocity * Time.deltaTime);
            }
            navAgent.velocity = characterController.velocity;
            //Kill self if I fall off the edge of the map
            if (transform.position.y < -30)
                Die();
        }
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


	public void AddKnockBack(Vector3 direction, float force)
	{
		KnockBack = direction.normalized * force;
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
        animator.SetTrigger("Die");
		//Object.Destroy(gameObject);
        //manager.enemySpawns[Random.Range(0, 4)].GetComponent<SpawnEnemies>().spawnedEnemies -= 1;
        manager.RegisterDeath();
        dying = true;
	}

    //Collision /w/ Player
	void OnControllerColliderHit(ControllerColliderHit col)
	{
        if (!dying)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerCollisions>().CollideWithEnemy(this);
            }

            if (col.gameObject.tag == "Fireball")
            {
                Damage(1);
                col.gameObject.GetComponent<FireballMovement>().health -= 1;
            }
        }
	}

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
