using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public List<GameObject> enemyInstance;
	public GameObject singleEnemyInstance;
	PlayerSpawner playerInstance;

	public int numLives = 1;
	public int gold;
	public int wood;
	public int level = 1;
	public int enemyNumber = 4;
	int previousEnemyCount;
	System.Random rnd;

	float respawnTimer;

	public GameObject playerSpawnerSpot;
	private PlayerSpawner playerSpawner;

	// Use this for initialization
	void Start () {
		playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();

		rnd = new System.Random();
		enemyInstance = new List<GameObject> ();
		for (int i = 0; i < enemyNumber; i++) {
			SpawnEnemy(rnd);
		}
		//spawned = true;
		previousEnemyCount = enemyNumber;
	}

	void SpawnEnemy(System.Random rnd) {

		gold = rnd.Next (1,50);
		wood = rnd.Next (1, 20);
		respawnTimer = 3.0f;
		//dodać pozycję miasta


		//Vector3 randomPosition = new Vector3((float)returnCoordinate(rnd)*5.0f, (float)returnCoordinate(rnd)*2.5f, 0.0f);
		Vector3 randomPosition = new Vector3((float)(-90.0f + returnCoordinate(rnd)*50.0f), (float)(-20.0f + returnCoordinate(rnd)*25.5f), 0.0f);
		singleEnemyInstance = (GameObject)Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
		//singleEnemyInstance.GetComponent<TriggerWalk>().enemy = playerSpawner.playerInstance.transform;
		enemyInstance.Add (singleEnemyInstance);
		previousEnemyCount = enemyInstance.Count;
	}

	// Update is called once per frame
	void Update () {

		if(enemyInstance.Count < enemyNumber) {
			//dodanie punktów za zniszczenie wroga
			playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
			respawnTimer -= Time.deltaTime;

			if (previousEnemyCount != enemyInstance.Count) {
				for(int i =0; i<previousEnemyCount - enemyInstance.Count; i++) {
					playerInstance.AddExp (100);
				}
				previousEnemyCount = enemyInstance.Count;
			}


			if(respawnTimer <= 0) {
				SpawnEnemy(rnd);
			}
		}

	}

	double returnCoordinate(System.Random rnd){
		bool minusValue;
		if (rnd.NextDouble() > 0.5) {
			minusValue = true;
		} else
			minusValue = false;
		if (minusValue)
			return -rnd.NextDouble();
		else
			return rnd.NextDouble();
	}


}
