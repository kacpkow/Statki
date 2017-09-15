using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButtonScript : MonoBehaviour {
	public PlayerSpawner playerSpawner;
	public bool enabled = false;
	public UnityEngine.UI.Button button;
	public bool fightInProgress = false;
	public bool readyToFight = false;
	public bool bossSpawned = false;

	// Use this for initialization
	void Start () {
		GameObject.Find("FightBossButton").GetComponentInChildren<UnityEngine.UI.Text>().text = "Fight with boss";
		button = gameObject.GetComponent<UnityEngine.UI.Button>();
		CanvasRenderer[] canvasRenderers = gameObject.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer c in canvasRenderers) {
			c.SetAlpha (0);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (playerSpawner.level >= 20 && playerSpawner.health > 0) {
			readyToFight = true;
		} else
			readyToFight = false;

		if (readyToFight == true && !fightInProgress && !enabled && !bossSpawned) {
			fightInProgress = true;
			enabled = true;
			bossSpawned = true;
			enableUI();
		}

		if(playerSpawner.health == 0){
			fightInProgress = false;
			enabled = false;
		}
	}

	public void enableUI(){
		CanvasRenderer[] canvasRenderers = gameObject.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer c in canvasRenderers) {
			c.SetAlpha (1);
		}
		button.interactable = true;
		
	}
	public void disableUI(){
		CanvasRenderer[] canvasRenderers = gameObject.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer c in canvasRenderers) {
			c.SetAlpha (0);
		}
		button.interactable = false;

	}
}
