using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenEnter : MonoBehaviour {

    //Attributes
    public AudioSource audioSource;
    public AudioClip[] clips;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}

}
