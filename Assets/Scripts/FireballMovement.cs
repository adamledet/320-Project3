using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    private CharacterController characterController;
    public float movementSpeed;
    public float movementCap;
    public float acceleration;
    public float health;

	// Use this for initialization
	void Start ()
    {
        characterController = GetComponent<CharacterController>();
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

        //Destroy Fireball when out of bounds
        if(transform.position.x >= 50 || transform.position.x <= -50 || transform.position.z >= 50 || transform.position.z <= -50)
        {
            Destroy(this.gameObject);
        }

        //Destroy Fireball after it expends its health
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
