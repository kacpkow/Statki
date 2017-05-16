using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByCollision : MonoBehaviour {
	List<GameObject> listOfAllObjects;
	PlayerSpawner playerInstance;
	LootsSpawner lootsSpawner;
	EnemySpawner enemyInstance;
	
	public float dyingSpeed = 2f;

	public int health = 1;

	void OnCollisionEnter2D(){
		Debug.Log ("Collision");

		health--;
	}

	void OnTriggerEnter2D(){
		Debug.Log ("Trigger");
		health--;
	}

	void Update(){
		if (health <= 0) {
			Die();
		}
	}

	void Die(){

		//Tonięcie
		/*
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0,0,-(Time.deltaTime*dyingSpeed));
		pos += velocity;
		if (pos.z <= -5f) {
			Destroy (gameObject);
		}
		transform.position = pos;
		*/

		//zestrzelony wrogi statek
		if (gameObject.name == "enemy(Clone)") {
			enemyInstance = GameObject.Find("EnemySpawnerSpot").GetComponent<EnemySpawner>();
			enemyInstance.enemyInstance.Remove (gameObject);
			playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
			playerInstance.gold += enemyInstance.gold;
			playerInstance.wood += enemyInstance.wood;
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			lootsSpawner = GameObject.Find ("LootsSpawner").GetComponent<LootsSpawner>();
			lootsSpawner.newLoot(pos, enemyInstance.gold);

		}
	
		Destroy (gameObject);

	}

	public void IncrementHealth(){
		health++;
	}
}
