using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public int startingWaveSize;
	public int minimumWaveIncrease;
	public int maximumWaveIncrese;
	public int maxActiveEnemies;
	public float spawnRate;
	public List<Area> spawnAreas;
	public List<SpawnEnemies> enemySpawns;

	private List<float> spawnPriority;
	private int waveSize;
	private int enemiesLeft;
	private int enemiesSpawned;

	// Use this for initialization
	void Start ()
    {
		if(maximumWaveIncrese < minimumWaveIncrease)
		{
			maximumWaveIncrese = 0;
		}
		waveSize = startingWaveSize;
		enemiesLeft = waveSize;
		enemiesSpawned = 0;
		spawnPriority = new List<float>();
		for(int i = 0; i < spawnAreas.Count; i++)
		{
			spawnPriority.Add(0);
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(enemiesLeft <= 0)
		{
			StartNextWave();
		}
		// active enemies are equal to the total enemies spawned - the size of the wave minus the enemies left before the next wave
		if(canSpawn)
		{
			float highest = 0;
			int index = 0;
			for(int i = 0; i < spawnAreas.Count; i++)
			{
				//at 60fps the spawn rate increses by 6% every second
				spawnPriority[i] += Time.deltaTime;
				//i would like to add the distance to the player to this will do it later
				if(spawnPriority[i] > highest)
				{
					highest = spawnPriority[i];
					index = i;
				}
			}
			Instantiate(enemy, spawnAreas[index].GetRandomPointInArea(), Quaternion.identity);
			enemiesSpawned++;
			spawnPriority[index] = 0;
		}
	}

	private bool canSpawn
	{
		get
		{
			return (enemiesSpawned - waveSize - enemiesLeft < maxActiveEnemies)&&(enemiesSpawned < waveSize);
		}
	}

	private void StartNextWave()
	{
		enemiesSpawned = 0;
		float increase = waveSize * 1.5f;
		if (increase < minimumWaveIncrease)
		{
			increase = minimumWaveIncrease;
		}
		else if (maximumWaveIncrese != 0 && increase > maximumWaveIncrese)
		{
			increase = maximumWaveIncrese;
		}
		waveSize += (int)increase;
		enemiesLeft = waveSize;
	}
    public void RegisterDeath()
    {
		enemiesLeft -= 1;
        enemySpawns[Random.Range(0, enemySpawns.Count)].spawnedEnemies -= 1;
    }
}
