using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    static public Rigidbody2D playerRB;
    static public string Weapon;
    public GameObject BattleScreen;
    public static bool OnGrass = false;
    public Scene WorldMap;
    public Scene CurrentScene;

    // Use this for initialization
    void Start ()
    {
        BattleScreen.SetActive(false);
        playerRB = GetComponent<Rigidbody2D>();
        Weapon = "Unarmed";

        CurrentScene = SceneManager.GetActiveScene();
        WorldMap = SceneManager.GetSceneByName("World Map");

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

        if (CurrentScene == WorldMap)
        {
            if (OnGrass == true)
            {
                speed = 2;
            }
            else
            {
                speed = 5;
            }
        }
        else
        {
            speed = 2;
        }
        

        
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
