using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CityPopUpController : MonoBehaviour {

    public Button sellAllButton;
    public Button repairShipButton;
    public Button upgradeShipButton;
    public Button upgradeCannonsButton;
    public Button upgradeSailsButton;

    public Text sellAllCost;
    public Text repairShipCost;
    public Text upgradeShipCost;
    public Text upgradeCannonsCost;
    public Text upgradeSailsCost;

    int staffPrice = 5;
    int repairPrice = 30;
    int upgradeShipPrice = 50;
    int upgradeCannonsPrice = 70;
    int upgradeSailsPrice = 60;

    // Use this for initialization
    void Start () {
        sellAllButton.onClick.AddListener(sellAllButtonOnClick);
        repairShipButton.onClick.AddListener(repairShipButtonOnClick);
        upgradeShipButton.onClick.AddListener(upgradeShipButtonOnClick);
        upgradeCannonsButton.onClick.AddListener(upgradeCannonsButtonOnClick);
        upgradeSailsButton.onClick.AddListener(upgradeSailsButtonOnClick);
    }

    private void sellAllButtonOnClick()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        playerSpawner.gold+= playerSpawner.wood * staffPrice;
        playerSpawner.wood = 0;
    }

    private void repairShipButtonOnClick()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        var damageByCollision = GameObject.Find("lodz(Clone)").GetComponent<DamageByCollision>();
        damageByCollision.health = playerSpawner.maxHealth;
        playerSpawner.gold -= repairPrice;
    }

    private void upgradeShipButtonOnClick()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        var damageByCollision = GameObject.Find("lodz(Clone)").GetComponent<DamageByCollision>();
        playerSpawner.gold -= ((playerSpawner.maxHealth - 3) / 2) * upgradeShipPrice;
        playerSpawner.maxHealth += 2;
        damageByCollision.health +=2;
        damageByCollision.health = playerSpawner.maxHealth;
    }

    private void upgradeCannonsButtonOnClick()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        playerSpawner.gold -= playerSpawner.canonsLvl * upgradeCannonsPrice;
        playerSpawner.canonsLvl++;
    }

    private void upgradeSailsButtonOnClick()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        playerSpawner.gold -= playerSpawner.sailsLvl * upgradeSailsPrice;
        playerSpawner.sailsLvl++;

        var playerMovement = GameObject.Find("lodz(Clone)").GetComponent<PlayerMovement>();
        playerMovement.maxSpeed++;
    }

    // Update is called once per frame
    void Update () {
        checkButtonDisable();
        calculateStaffPrice();
        calculateRepairShipCost();
        calculateUpgradeShipCost();
        calculateUpgradeCannonsCost();
        calculateUpgradeSailsCost();

    }

    private void checkButtonDisable()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        var damageByCollision = GameObject.Find("lodz(Clone)").GetComponent<DamageByCollision>();

        int gold = playerSpawner.gold;
        int wood = playerSpawner.wood;
        int health = damageByCollision.health;
        int maxHealth = playerSpawner.maxHealth;
        int shipLvl = playerSpawner.shipLvl;
        int canonsLvl = playerSpawner.canonsLvl;
        int sailsLvl = playerSpawner.sailsLvl;


        //upgrade Ship
        if (((maxHealth - 3) / 2) * upgradeShipPrice <= gold){
            upgradeShipButton.enabled = true;
        }
        else{
            upgradeShipButton.enabled = false;
        }

        //repair
        if ((health != maxHealth) && (gold > repairPrice))
        {
            repairShipButton.enabled = true;
        }
        else
        {
            repairShipButton.enabled = false;
        }

        //upgrade cannons
        if (canonsLvl * upgradeCannonsPrice <= gold)
        {
            upgradeCannonsButton.enabled = true;
        }
        else
        {
            upgradeCannonsButton.enabled = false;
        }

        //upgrade sails
        if (sailsLvl * upgradeSailsPrice <= gold)
        {
            upgradeSailsButton.enabled = true;
        }
        else
        {
            upgradeSailsButton.enabled = false;
        }

        //sell
        if(wood > 0)
        {
            sellAllButton.enabled = true;
        }
        else
        {
            sellAllButton.enabled = false;  
        }
    }

    private void calculateStaffPrice()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();

        sellAllCost.text = ""+(playerSpawner.wood * staffPrice);
    }

    private void calculateRepairShipCost()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        repairShipCost.text = "" + repairPrice;
    }

    private void calculateUpgradeShipCost()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        upgradeShipCost.text = "" + (((playerSpawner.maxHealth - 3) / 2) * upgradeShipPrice);
    }

    private void calculateUpgradeCannonsCost()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        upgradeCannonsCost.text = "" + (playerSpawner.canonsLvl * upgradeCannonsPrice);
    }

    private void calculateUpgradeSailsCost()
    {
        var playerSpawner = GameObject.Find("PlayerSpawnerSpot").GetComponent<PlayerSpawner>();
        upgradeSailsCost.text = "" + (playerSpawner.sailsLvl * upgradeSailsPrice);
    }

  
}
