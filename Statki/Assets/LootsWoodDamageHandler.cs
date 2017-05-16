using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsWoodDamageHandler : MonoBehaviour {
	PlayerSpawner playerInstance;
	public LootHealth lootHealth;

	int active = 1;
	static int goodAmount;
	void OnCollisionEnter2D(){
		Debug.Log ("Assigned in collision "+goodAmount);
		playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
		playerInstance.AddHealth ();
		lootHealth = gameObject.GetComponent<LootHealth> ();
		playerInstance.AddWood(lootHealth.amount);
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
