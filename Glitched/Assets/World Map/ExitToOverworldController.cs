﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToOverworldController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
            CurrencyController.playerMoney--;
            int money = PlayerPrefs.GetInt("PlayerMoney");
            money--;
            PlayerPrefs.SetInt("PlayerMoney", money);
        }
    }
}
