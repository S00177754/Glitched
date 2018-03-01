using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    static public Rigidbody2D playerRB;
     public static bool OnGrass;

    // Use this for initialization
    void Start ()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        Scene Rn = SceneManager.GetSceneByName("World Map");

        playerRB = GetComponent<Rigidbody2D>();

        if (CurrentScene == Rn)
        {
            speed = 5;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        

       

        if(OnGrass == true)
        {
            speed = 2;
        }
        else if(OnGrass == false)
        {
            speed = 5;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        
        
    }

}
