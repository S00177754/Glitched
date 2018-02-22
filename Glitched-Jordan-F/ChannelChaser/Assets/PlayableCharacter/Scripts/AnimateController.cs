using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateController : MonoBehaviour {

    private Animator player;
    bool test;
	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
                player.SetTrigger("North");
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.SetTrigger("West");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.SetTrigger("South");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.SetTrigger("East");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            player.SetTrigger("Idle");
        }

    }

    void AnimBoolFalse()
    {
        player.SetBool("North", false);
        player.SetBool("West", false);
        player.SetBool("East", false);
        player.SetBool("South", false);
    }
}
