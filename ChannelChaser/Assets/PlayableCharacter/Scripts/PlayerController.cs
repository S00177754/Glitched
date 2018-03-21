using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    static public Rigidbody2D playerRB;
    static public string Weapon;
    public GameObject BattleScreen;

    // Use this for initialization
    void Start ()
    {
        BattleScreen.SetActive(false);
        playerRB = GetComponent<Rigidbody2D>();
        Weapon = "Unarmed";
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Switch")
        {
            BridgeController.SwitchOn = true;
        }
        else if(collision.gameObject.tag == "Beholder")
        {
            BattleScreen.SetActive(true);
            CharacterScript.monsterName = "BeholderInit";
        }
    }
}
