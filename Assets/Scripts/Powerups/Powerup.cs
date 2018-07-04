using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public float health = 15f; //default health gain
    public PowerupHandler powerupHandler;

    private void Start()
    {
        powerupHandler = GetComponentInParent<PowerupHandler>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("You have picked up a powerup");
            Pickup(col);
            if (col.transform.GetComponent<PlayerController>() != null)
            {
                //disable player1
                col.transform.GetComponent<PlayerController>().enabled = false;
                //play animation
                //change bool in poweruphandler
                powerupHandler.player1 = false;
                //check if all players picked up powerups
                powerupHandler.CheckPowerup();
            }

            //check if player 2 pickedup pickup
            if (col.transform.GetComponent<Player2Controller>() != null)
            {
                //disable player 2
                col.transform.GetComponent<PlayerController>().enabled = false;
                //play animation                
                //make a transition to next level if player
                powerupHandler.player2 = false;
                //check if all players picked up powerups
                powerupHandler.CheckPowerup();
            }
        }       
        
    } 
 
    protected virtual void Pickup(Collider2D col)
    {
        PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
        playerController.health += 5;
        playerController.HealthUpdate(playerController.health);

        //Destroy game object
        Destroy(gameObject);
    }
}
