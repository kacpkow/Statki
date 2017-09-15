using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWithBoss : MonoBehaviour {

	public Button myButton;
	public GameObject boss;
	public GameObject bossPrefab;
	Vector3 bossSpawner;

	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button> ();
		bossSpawner.x = -26;
		bossSpawner.y = -5;
		bossSpawner.z = 0;
	}

	public void Fight(){
		myButton.interactable = false;
		CanvasRenderer[] canvasRenderers = gameObject.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer c in canvasRenderers) {
			c.SetAlpha (0);
		}
		boss = (GameObject)Instantiate (bossPrefab, bossSpawner, Quaternion.identity);
	}

	void Destroy(){
		myButton.onClick.RemoveListener (() => Fight ());
	}
}
