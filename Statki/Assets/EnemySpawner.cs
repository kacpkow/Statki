using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public List<GameObject> enemyInstance;
	public GameObject singleEnemyInstance;

	public int numLives = 1;
	public int gold;
	public int wood;
	public int level = 1;
	public int enemyNumber = 4;
	System.Random rnd;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		rnd = new System.Random();
		enemyInstance = new List<GameObject> ();
		for (int i = 0; i < enemyNumber; i++) {
			SpawnEnemy(rnd);
		}
	}

	void SpawnEnemy(System.Random rnd) {
		
		gold = rnd.Next (1,50);
		wood = rnd.Next (1, 20);
		respawnTimer = 3.0f;
		//dodać pozycję miasta


		Vector3 randomPosition = new Vector3((float)returnCoordinate(rnd)*5.0f, (float)returnCoordinate(rnd)*2.5f, 0.0f);
		singleEnemyInstance = (GameObject)Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
		enemyInstance.Add (singleEnemyInstance);
	}

	// Update is called once per frame
	void Update () {

		if(enemyInstance.Count < 4) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				SpawnEnemy(rnd);
			}
		}
	
	}
	void OnGUI() {
			GUI.Label( new Rect(400, 0, 500, 50), "Enemies: ");

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
