﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour {

    public GameObject UIMenu;
    public GameObject ItemsMenu;
    public GameObject FlintlockMenu;
    public GameObject CrossbowMenu;
    public GameObject MagicMenu;
    public GameObject SwordMenu;
    public GameObject UnarmedMenu;
    public GameObject OpacityGreyOut;

    //Layer1
    public Button attackButton;
    public Button defendButton;
    public Button itemButton;
    public Button fleeButton;

    //Items-Potions
    public Button hpPotAmount;
    public Button mpPotAmount;
    public Button strengthPotAmount;
    public Button shieldPotAmount;

    //Potion Amounts
    static public int HPPotAmount;
    static public int MPPotAmount;
    static public int ShieldPotAmount;
    static public int StrengthPotAmount;

    // Use this for initialization
    void Start ()
    {
        //MainUI
        attackButton.onClick.AddListener(AttackMenu);
        defendButton.onClick.AddListener(Defend);
        itemButton.onClick.AddListener(ItemMenu);
        fleeButton.onClick.AddListener(Flee);

        //PotionsUI
        hpPotAmount.onClick.AddListener(HealthPot);
        mpPotAmount.onClick.AddListener(MagicPot);
        strengthPotAmount.onClick.AddListener(StrengthPot);
        shieldPotAmount.onClick.AddListener(ShieldPot);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Layer 1
    void AttackMenu()
    {
        if (PlayerController.Weapon == "Sword")
        {
            DisableOne();
            SwordMenu.SetActive(true);
        }
        else if (PlayerController.Weapon == "Crossbow")
        {
            DisableOne();
            CrossbowMenu.SetActive(true);
        }
        else if (PlayerController.Weapon == "Magic")
        {
            DisableOne();
            MagicMenu.SetActive(true);
        }
        else if (PlayerController.Weapon == "Flintlock")
        {
            DisableOne();
            FlintlockMenu.SetActive(true);
        }
        else //Unarmed
        {
            DisableOne();
            UnarmedMenu.SetActive(true);
        }
    }

    void Defend()
    {
        DisableOne();

    }

    void ItemMenu()
    {
        DisableOne();
        ItemsMenu.SetActive(true);
    }

    void Flee()
    {
        DisableOne();
    }

    //Potions
    void HealthPot()
    {
        if (HPPotAmount >= 1)
        {
            HPPotAmount--;
            GreyOut();

        }
    }

    void MagicPot()
    {
        if (MPPotAmount >= 1)
        {
            MPPotAmount--;
            GreyOut();
        }

    }

    void StrengthPot()
    {
        if (StrengthPotAmount >= 1)
        {
            StrengthPotAmount--;
            GreyOut();
        }
    }

    void ShieldPot()
    {
        if (ShieldPotAmount >= 1)
        {
            ShieldPotAmount--;
            GreyOut();
        }
    }

    //Disable Methods
    void DisableOne()
    {
        SwordMenu.SetActive(false);
        CrossbowMenu.SetActive(false);
        FlintlockMenu.SetActive(false);
        MagicMenu.SetActive(false);
        UnarmedMenu.SetActive(false);

        UIMenu.SetActive(false);
        ItemsMenu.SetActive(false);
    }

    void GreyOut()
    {
        OpacityGreyOut.SetActive(true);
    }
}

