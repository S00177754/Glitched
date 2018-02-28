using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    static public Rigidbody2D playerRB;
    
    // Use this for initialization
    void Start ()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        Scene Rn = SceneManager.GetSceneByName("World Map");
        

        if(CurrentScene == Rn)
        {
            speed = 10;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        
        
    }

    
}
