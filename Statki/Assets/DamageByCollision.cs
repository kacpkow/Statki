using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByCollision : MonoBehaviour {

	public float dyingSpeed = 2f;

	public int health = 1;

	void OnCollisionEnter2D(){
		Debug.Log ("Collision");
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
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0,0,-(Time.deltaTime*dyingSpeed));
		pos += velocity;
		transform.position = pos;
		//Destroy (gameObject);
	}
}
