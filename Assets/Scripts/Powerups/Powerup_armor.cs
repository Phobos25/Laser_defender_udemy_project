using UnityEngine;
using System.Collections;

public class Powerup_armor : Powerup {


    #region Unity Methods



    protected override void Pickup(Collider2D col)
    {
        PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
        //check if player 1 picked up
        if (playerController)
        {
            playerController.health += 10;
            playerController.HealthUpdate(playerController.health);

            Destroy(gameObject);
        }    
        else
        {
            Player2Controller player2Controller = col.gameObject.GetComponent<Player2Controller>();
            player2Controller.health += 10;
            player2Controller.HealthUpdate(player2Controller.health);

            Destroy(gameObject);

        }

    }

    #endregion
}
