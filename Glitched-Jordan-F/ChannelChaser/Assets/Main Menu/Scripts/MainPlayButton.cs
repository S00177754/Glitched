﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

       
		
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}
    private void OnMouseDown()
    {
        SceneManager.LoadScene(0); // Build number of scene you want.
    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().flipX = false;

        
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }
}
