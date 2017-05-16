using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootsSpawner : MonoBehaviour {
	public GameObject woodPrefab;
	public GameObject singleWoodLootInstance;
	Vector3 position;

	void Start(){
		SpawnLoot ();
	}

	void SpawnLoot(){
		singleWoodLootInstance = (GameObject)Instantiate(woodPrefab, position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void newLoot(Vector3 pos){
		position = pos;
		Start ();
	}
}
