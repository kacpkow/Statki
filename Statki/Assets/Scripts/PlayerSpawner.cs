using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;
	public GameObject playerInstance;

	public int numLives = 1;
	public int gold = 0;
	public int wood = 0;
	public int expPoints = 0;
	int lastLostExpPoints;
	public int level = 1;
<<<<<<< HEAD
	public bool GUIEnabled = false;
	int time = 0;
	Vector3 spawnerPosition;
=======
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995

	float respawnTimer;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		spawnerPosition.x = -26;
		spawnerPosition.y = 32;
		spawnerPosition.z = 0;
=======
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995
		SpawnPlayer();
	}

	//resp gracza ze stratami
	void SpawnPlayerWithLoss(){
<<<<<<< HEAD
		GUIEnabled = true;
=======
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995
		if (gold - (level * 100) >= 0)
			gold -= level * 100;
		else
			gold = 0;

		if (wood - (level * 30) >= 0)
			wood -= level * 30;
		else
			wood = 0;
		
		numLives = 1;

		if ((expPoints - (lastLostExpPoints + 100) >= 0))
			expPoints -= (lastLostExpPoints + 100);
		else
			expPoints = 0;
<<<<<<< HEAD

		playerInstance = (GameObject)Instantiate(playerPrefab, spawnerPosition, Quaternion.identity);
		respawnTimer = 5;
	}

	void SpawnPlayer() {
		respawnTimer = 5;
		//dodać pozycję miasta
		playerInstance = (GameObject)Instantiate(playerPrefab, spawnerPosition, Quaternion.identity);
=======
		
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}

	void SpawnPlayer() {
		respawnTimer = 1;
		//dodać pozycję miasta
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995
	}

	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
<<<<<<< HEAD
			time++;
			if (time % 100 < 50) {
				GUIEnabled = true;
			} 
			else {
				GUIEnabled = false;			
			}



			if(respawnTimer <= 0) {
				SpawnPlayerWithLoss();
				time = 0;
=======

			if(respawnTimer <= 0) {
				SpawnPlayerWithLoss();
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995
			}
		}
	}

	void OnGUI() {
<<<<<<< HEAD
		if (playerInstance != null) {
			GUI.contentColor = Color.black;
			GUI.Label (new Rect (0, 0, 100, 50), "Health: " + playerInstance.GetComponent<DamageByCollision> ().health);
			GUI.Label (new Rect (100, 0, 200, 50), "Money: " + gold);
			GUI.Label (new Rect (200, 0, 300, 50), "Wood: " + wood);
			GUI.Label (new Rect (300, 0, 350, 50), "Exp: " + expPoints);
		} else {
			GUI.contentColor = Color.black;
			GUI.Label (new Rect (0, 0, 100, 50), "Health: 0");
			GUI.Label (new Rect (100, 0, 200, 50), "Money: " + gold);
			GUI.Label (new Rect (200, 0, 300, 50), "Wood: " + wood);
			GUI.Label (new Rect (300, 0, 350, 50), "Exp: " + expPoints);
			if (GUIEnabled) {
				GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "You have been shooted");
			}
		}

=======
		if(numLives > 0 || playerInstance!= null) {
			GUI.contentColor = Color.black;
			GUI.Label( new Rect(0, 0, 100, 50), "Health: " + playerInstance.GetComponent<DamageByCollision>().health);
			GUI.Label( new Rect(100, 0, 200, 50), "Money: " + gold);
			GUI.Label( new Rect(200, 0, 300, 50), "Wood: " + wood);
			GUI.Label( new Rect(300, 0, 350, 50), "Exp: " + expPoints);
		}
		else {
			GUI.Label( new Rect( Screen.width/2 - 50 , Screen.height/2 - 25, 100, 50), "You have been shooted");

		}
>>>>>>> ffa4ac8f7bf789989fff9179d7d729d3d3a2f995
	}

	void AddLevelPoints (){
	}

	void LevelController(){
		
	}

	public void AddHealth(){
		if (playerInstance != null) {
			playerInstance.GetComponent<DamageByCollision> ().IncrementHealth();
		}
	}

	public void AddWood(int amount){
		if (playerInstance != null) {
			wood += amount;
		}
	}

	public void AddGold(int amount){
		if (playerInstance != null) {
			gold += amount;
		}
	}

	public void AddExp(int amount){
		expPoints += amount;
	}
		
}
