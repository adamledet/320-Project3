using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    private CharacterController characterController;
    public float movementSpeed;
    public float movementCap;
    public float acceleration;
    public float explosionRadius;

	// Use this for initialization
	void Start ()
    {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        if (movementSpeed < movementCap)
            movementSpeed += acceleration;
        else
            movementSpeed = movementCap;
	}
}
