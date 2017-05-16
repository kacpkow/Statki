using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsDamageHandler : MonoBehaviour {
	PlayerSpawner playerInstance;

	int active = 1;
	int goodAmount;
	void OnCollisionEnter2D(){
		playerInstance = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
		playerInstance.AddHealth ();
		Debug.Log (goodAmount);
		playerInstance.AddWood (goodAmount);
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

	public void setGoodsAmount(int amount){
		goodAmount = amount;
	}

}
