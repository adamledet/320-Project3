using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public GameObject instructionsScreen;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        //Press 'p' to Play
        if(Input.GetKeyDown("p") && SceneManager.GetActiveScene().name == "TitleScreen")
        {
            SceneManager.LoadScene("Game");
        }

        //Press 'i' for Instructions
        if (Input.GetKeyDown("i") && SceneManager.GetActiveScene().name == "TitleScreen")
        {
            instructionsScreen.SetActive(!instructionsScreen.activeSelf);
        }

        //Press 'q' to Quit
        if(Input.GetKeyDown("q") && SceneManager.GetActiveScene().name == "TitleScreen")
        {
            Application.Quit();
        }
    }

    //Change Scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void CloseProgram()
	{
		Application.Quit();
	}
}
