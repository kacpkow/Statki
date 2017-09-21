using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public PlayerSpawner player;
    public GameObject endGameWindow;

    public GameObject boss;

    public Button exit;

	// Use this for initialization
	void Start () {
        boss = GameObject.Find("boss1(Clone)");

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void exitOnClick()
    {
        Application.Quit();
    }
}
