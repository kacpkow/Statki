using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsWoodDamageHandler : MonoBehaviour {
	PlayerSpawner playerInstance;
	public LootHealth lootHealth;
	public float activeTime = 5.0f;

	int active = 1;
	static int goodAmount = 1;
	void OnCollisionEnter2D(){
		Debug.Log ("Assigned in collision "+goodAmount);
		playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
		playerInstance.AddHealth ();
		lootHealth = gameObject.GetComponent<LootHealth> ();
		playerInstance.AddWood(lootHealth.amount);
		active--;
	}

	void Update(){
		activeTime -= Time.deltaTime;
		if (active <= 0 || activeTime <= 0.0f) {
			Die();
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
