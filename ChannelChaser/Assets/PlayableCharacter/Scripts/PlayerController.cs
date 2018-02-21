using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    static public Rigidbody2D playerRB;
    int blastForce = 5;
    // Use this for initialization
    void Start ()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        
        
    }

    void OnTriggerEnter2D()
    {
        if (gameObject.tag == "Cannon")
        {
            playerRB.AddForce(transform.forward * blastForce);
        }
    }
}
