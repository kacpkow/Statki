using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PirateRanks{
	public static string boatswain{get{return "Boatswain";}}
	public static string powderMonkey{get{return "Powder Monkey";}}
	public static string gunner{get{return "Gunner";}}
	public static string sailingMaster{get{return "Sailing Master";}}
	public static string quarterMaster{get{return "Quarter Master";}}
	public static string firstMate{get{return "First Mate";}}
	public static string captain{get{return "Captain";}}

}

public class PlayerSpawner : MonoBehaviour {
	public GameObject playerPrefab;
	public GameObject playerInstance;

	public int numLives = 1;
	public int gold = 0;
	public int wood = 0;
	public int expPoints = 0;
	public int health = 0;
	int lastLostExpPoints = 0;
	public int level = 1;
	public int pointsFactor = 100;
	public bool GUIEnabled = false;
	int time = 0;
	Vector3 spawnerPosition;
	string currentRank = PirateRanks.boatswain;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		spawnerPosition.x = -27;
		spawnerPosition.y = 30;
		spawnerPosition.z = 0;
		SpawnPlayer();
	}

	//resp gracza ze stratami
	void SpawnPlayerWithLoss(){
		GUIEnabled = true;
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

		playerInstance = (GameObject)Instantiate(playerPrefab, spawnerPosition, Quaternion.identity);
		respawnTimer = 5;
	}

	void SpawnPlayer() {
		respawnTimer = 5;
		//dodać pozycję miasta
		playerInstance = (GameObject)Instantiate(playerPrefab, spawnerPosition, Quaternion.identity);

		//playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}
		
	// Update is called once per frame
	void Update () {
		if (playerInstance != null) {
			health = playerInstance.GetComponent<DamageByCollision> ().health;
		} else {
			health = 0;
		}

		if (playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;
			time++;
			if (time % 100 < 50) {
				GUIEnabled = true;
			} else {
				GUIEnabled = false;			
			}



			if (respawnTimer <= 0) {
				SpawnPlayerWithLoss ();
				time = 0;
				if (respawnTimer <= 0) {
					SpawnPlayerWithLoss ();
				}
			}
		}

		//level checking
		if (expPoints >= (level * 1000) + (level * pointsFactor)) {
				AddLevelPoints ();
				expPoints = 0;
				lastLostExpPoints = 0;
		}

		//rank checking
		switch (level) {
		case 2:
			currentRank = PirateRanks.powderMonkey;
			break;
		case 4:
			currentRank = PirateRanks.gunner;
			break;
		case 7:
			currentRank = PirateRanks.sailingMaster;
			break;
		case 10:
			currentRank = PirateRanks.quarterMaster;
			break;
		case 15:
			currentRank = PirateRanks.firstMate;
			break;
		case 20:
			currentRank = PirateRanks.captain;
			break;
		}


	}

		void OnGUI() {
				
			if(numLives > 0 && playerInstance!= null) {
				GUI.contentColor = Color.black;
				GUI.Label( new Rect(0, 0, 100, 50), "Health: " + health);
				GUI.Label( new Rect(100, 0, 200, 50), "Money: " + gold);
				GUI.Label( new Rect(200, 0, 300, 50), "Wood: " + wood);
				GUI.Label (new Rect (300, 0, 400, 50), "Level: " + level);
				GUI.Label (new Rect (400, 0, 500, 50), "Exp: " + expPoints);
				GUI.Label (new Rect (500, 0, 600, 50), "Current rank: " + currentRank);
			}
			else {
				GUI.contentColor = Color.black;
				GUI.Label( new Rect(0, 0, 100, 50), "Health: " + health);
				GUI.Label( new Rect(100, 0, 200, 50), "Money: " + gold);
				GUI.Label( new Rect(200, 0, 300, 50), "Wood: " + wood);
				GUI.Label (new Rect (300, 0, 400, 50), "Level: " + level);
				GUI.Label (new Rect (400, 0, 500, 50), "Exp: " + expPoints);
				GUI.Label (new Rect (500, 0, 600, 50), "Current rank: " + currentRank);
				if (GUIEnabled) {
					
					GUI.Label( new Rect( Screen.width/2 - 50 , Screen.height/2 - 25, 100, 50), "Your ship has been destroyed");

				}
				
			}
		}

		void AddLevelPoints (){
		level += 1;
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
