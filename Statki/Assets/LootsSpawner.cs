using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsSpawner : MonoBehaviour {
	public GameObject woodPrefab;
	public GameObject singleWoodLootInstance;
	public LootsDamageHandler damageHandler;
	Vector3 position;
	int amount;

	void Start(){
		SpawnLoot ();
	}

	void SpawnLoot(){
		Debug.Log ("Wood: "+amount);
		damageHandler = woodPrefab.GetComponent<LootsDamageHandler> ();
		damageHandler.setGoodsAmount (amount);
		singleWoodLootInstance = (GameObject)Instantiate(woodPrefab, position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void newLoot(Vector3 pos, int amount){
		position = pos;
		amount = amount;
		Start ();
	}
}
