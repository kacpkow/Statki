using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsGoldDamageHandler : MonoBehaviour {

	PlayerSpawner playerInstance;
	public LootHealth lootHealth;

	int active = 1;
	static int goodAmount;
	public float activeTime = 5.0f;

	void OnCollisionEnter2D(){
		Debug.Log ("Assigned in collision "+goodAmount);
		playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
		lootHealth = gameObject.GetComponent<LootHealth> ();
		playerInstance.AddGold(lootHealth.amount);
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
