using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    private CharacterController characterController;
    public float movementSpeed;
    public float movementCap;
    public float acceleration;
    public float health;
    public float range;
    private Vector3 startPosition;

	// Use this for initialization
	void Start ()
    {
        characterController = GetComponent<CharacterController>();
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Fireball speeds up
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        if (movementSpeed < movementCap)
            movementSpeed += acceleration;
        else
            movementSpeed = movementCap;

        //Damage Fireball as it travels
        if(Vector3.Distance(startPosition, transform.position) >= range)
        {
            health -= 3;
        }

        //Destroy Fireball after it expends its health
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
