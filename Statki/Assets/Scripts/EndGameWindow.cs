using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameWindow : MonoBehaviour {
    public PlayerSpawner playerSpawner;
    public GameObject Panel;

    public void showhidePanel()
    {
        if(playerSpawner.health > 0)
        {
            Panel.gameObject.setActive(false);
        }
        else
        {
            Panel.gameObject.setActive(true);
        }
    }

}
