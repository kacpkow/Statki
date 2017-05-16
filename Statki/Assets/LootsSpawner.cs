using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsSpawner : MonoBehaviour {
	public GameObject woodPrefab;
	public GameObject goldPrefab;
	public GameObject singleWoodLootInstance;
	public GameObject singleGoldLootInstance;
	public LootsWoodDamageHandler damageHandlerWoodPrefab;
	public LootsGoldDamageHandler damageHandlerGoldPrefab;
	public LootHealth lootWoodHealth;
	public LootHealth lootGoldHealth;
	Vector3 position;
	int wood;
	int gold;

	void Start(){
		SpawnLoot ();
	}

	void SpawnLoot(){
		//spawning wood loot
		singleWoodLootInstance = (GameObject)Instantiate(woodPrefab, position, Quaternion.identity);
		damageHandlerWoodPrefab = woodPrefab.GetComponent<LootsWoodDamageHandler> ();
		lootWoodHealth = woodPrefab.GetComponent<LootHealth> ();
		lootWoodHealth.UpdateAmount (wood);

		//spawning gold loot
		singleGoldLootInstance = (GameObject)Instantiate(goldPrefab, position, Quaternion.identity);
		damageHandlerGoldPrefab = goldPrefab.GetComponent<LootsGoldDamageHandler> ();
		lootGoldHealth = goldPrefab.GetComponent<LootHealth> ();
		lootGoldHealth.UpdateAmount (gold);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void newLoot(Vector3 pos, int woodAmount, int goldAmount){
		position = pos;
		wood = woodAmount;
		gold = goldAmount;
		Start ();
	}
}
