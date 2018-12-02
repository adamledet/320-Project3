using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //Change Scene
    public void ChangeScene(string sceneName)
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(sceneName);
    }
}
