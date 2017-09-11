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

    float sellAllCost = 0;
    float repairShipCost = 0;
    float upgradeShipCost = 100;
    float upgradeCannonsCost = 100;
    float upgradeSailsCost = 100;

    float staffPrice;

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
        throw new NotImplementedException();
    }

    private void repairShipButtonOnClick()
    {
        throw new NotImplementedException();
    }

    private void upgradeShipButtonOnClick()
    {
        throw new NotImplementedException();
    }

    private void upgradeCannonsButtonOnClick()
    {
        throw new NotImplementedException();
    }

    private void upgradeSailsButtonOnClick()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
        calculateStaffPrice();
        calculateRepairShipCost();
        calculateUpgradeShipCost();
        calculateUpgradeCannonsCost();
        calculateUpgradeSailsCost();

    }

    private void calculateStaffPrice()
    {
        throw new NotImplementedException();
    }

    private void calculateRepairShipCost()
    {
        throw new NotImplementedException();
    }

    private void calculateUpgradeShipCost()
    {
        throw new NotImplementedException();
    }

    private void calculateUpgradeCannonsCost()
    {
        throw new NotImplementedException();
    }

    private void calculateUpgradeSailsCost()
    {
        throw new NotImplementedException();
    }

  
}
