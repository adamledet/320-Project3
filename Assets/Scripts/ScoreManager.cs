using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //Attributes
    public float score;
    public GameObject scoreDisplay;
    public GameObject waveDisplay;
    public Slider enemyMeter;
    private int wave;
    private float maxEnemies;
    private float enemiesLeft;

	// Use this for initialization
	void Start ()
    {
        wave = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().WaveNumber;
        maxEnemies = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().WaveSize;
        enemiesLeft = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().EnemiesLeft;
        score = 0;
        UpdateScore();
	}
	
	// Update Score Display
    public void UpdateScore()
    {
        scoreDisplay.GetComponent<Text>().text = score.ToString();
        wave = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().WaveNumber;
        if(wave < 10)
            waveDisplay.GetComponent<Text>().text = "Wave 0" + wave;
        else
            waveDisplay.GetComponent<Text>().text = "Wave " + wave;
        maxEnemies = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().WaveSize;
        enemiesLeft = GameObject.Find("EnemyManager").GetComponent<EnemyManager>().EnemiesLeft;
        enemyMeter.maxValue = maxEnemies;
        enemyMeter.value = maxEnemies - enemiesLeft;
    }
}
