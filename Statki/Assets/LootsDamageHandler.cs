using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsDamageHandler : MonoBehaviour {
	PlayerSpawner playerInstance;

	int active = 1;
	void OnCollisionEnter2D(){
		playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
		playerInstance.AddHealth ();
		active--;
	}

	void Update(){
		if (active <= 0) {
			Die();
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
