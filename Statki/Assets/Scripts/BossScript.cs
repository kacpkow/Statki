using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

	public PlayerSpawner playerSpawner;
	public bool readyToFight = false;
	public bool bossSpawned = false;
	public GameObject boss;
	public GameObject bossPrefab;
	Vector3 bossSpawner;

	// Use this for initialization
	void Start () {
		bossSpawner.x = -26;
		bossSpawner.y = -5;
		bossSpawner.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerSpawner.level >= 2 && playerSpawner.health > 0) {
			readyToFight = true;
		} else
			readyToFight = false;

		if (readyToFight == true && !bossSpawned) {
			SpawnBoss ();
			bossSpawned = true;
		}

	}

	void SpawnBoss(){
		boss = (GameObject)Instantiate (bossPrefab, bossSpawner, Quaternion.identity);
	}
}
