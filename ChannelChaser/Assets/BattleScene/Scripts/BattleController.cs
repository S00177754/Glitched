using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    CharacterScript playerScript;
    CharacterScript enemyScript;

    public Text playerHealth;
    public Text playerAP;

    public Text enemyHealth;
    public Text enemyAP;

    // Use this for initialization
    void Start () {
        playerScript = Player.GetComponent<CharacterScript>();
        enemyScript = Enemy.GetComponent<CharacterScript>();
    }
	
	// Update is called once per frame
	void Update () {
        playerHealth.text = "Health: " + playerScript.Health;
        playerAP.text = "AP: " + playerScript.ActionPoints;

        enemyHealth.text = "Health: " + enemyScript.Health;
        enemyAP.text = "AP: " + enemyScript.ActionPoints;
    }

    public void AddCharactersToBattle(GameObject player, GameObject enemy)
    {
        player.AddComponent(typeof(CharacterScript));
        enemy.AddComponent(typeof(CharacterScript));

        playerScript = player.GetComponent<CharacterScript>();
        playerScript.isCharactersTurn = true;

        enemyScript = enemy.GetComponent<CharacterScript>();
        enemyScript.isAI = true;

        playerScript.opponent = enemyScript;
        enemyScript.opponent = playerScript;
    }
}
