using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //Attributes
    public float score;
    public GameObject scoreDisplay;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        UpdateScore();
	}
	
	// Update Score Display
    public void UpdateScore()
    {
        scoreDisplay.GetComponent<Text>().text = score.ToString();
    }
}
