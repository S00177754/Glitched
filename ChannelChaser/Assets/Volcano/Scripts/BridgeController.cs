using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour {
    //Variables
    static public bool SwitchOn;
    SpriteRenderer sprite;
    Collider2D bridgeBlock;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();

        sprite.enabled = true;
        SwitchOn = false;

        if (gameObject.tag == "Bridge")
        {
            sprite.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(SwitchOn == true)
        {
            sprite.enabled = true;

        }


	}

}
