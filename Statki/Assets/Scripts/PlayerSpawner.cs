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


	float respawnTimer;

	// Use this for initialization
	void Start () {

		SpawnPlayer();
	}

	//resp gracza ze stratami
	void SpawnPlayerWithLoss(){

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

		
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}

	void SpawnPlayer() {
		respawnTimer = 1;
		//dodać pozycję miasta
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;


			if(respawnTimer <= 0) {
				SpawnPlayerWithLoss();

			}
		}
	}

	void OnGUI() {

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
