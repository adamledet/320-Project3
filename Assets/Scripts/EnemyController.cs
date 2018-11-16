using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour {

    //Target Attributes
	private CharacterController characterController;
	// once we have more code for the player we might change this
	private GameObject target;

    //SPeed Controller
	public float maxSpeed;


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}

	void OnEnable()
	{
		// this is temporary, im pretty sure calling find is expensive in terms of processing, will do this another way later
		target = GameObject.Find("FPSController");
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
	}
}
