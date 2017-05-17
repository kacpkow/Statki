using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructBullet : MonoBehaviour {

	public float timer = 2.2f;

	void Update () {
		timer -= Time.deltaTime;

		if(timer <= 0) {
			Destroy(gameObject);
		}
	}
}
