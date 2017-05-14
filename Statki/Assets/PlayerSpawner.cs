using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	public int numLives = 4;
	public int gold = 0;
	public int wood = 0;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		SpawnPlayer();
	}

	void SpawnPlayer() {
		numLives--;
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				SpawnPlayer();
			}
		}
	}

	void OnGUI() {
		if(numLives > 0 || playerInstance!= null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Health: " + playerInstance.GetComponent<DamageByCollision>().health);
			GUI.Label( new Rect(100, 0, 200, 50), "Money: " + gold);
			GUI.Label( new Rect(200, 0, 300, 50), "Wood: " + wood);
		}
		else {
			GUI.Label( new Rect( Screen.width/2 - 50 , Screen.height/2 - 25, 100, 50), "Game Over, Man!");

		}
	}
}
