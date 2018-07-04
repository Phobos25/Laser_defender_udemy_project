using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    public LevelManager lm;
    public Powerup[] powerup;
    public Transform[] spawnPos;

    public bool player1;
    public bool player2;

	// Use this for initialization
	void Start ()
    {
        //check if 
        if (spawnPos == null)
        {
            Debug.Log(transform.name + " no spawn positions for powerups");
        }
        else
        {
            SpawnPowerup();
        }

        player1 = true;
        if (Data.instance.TwoPlayerEnabled)
        {
            player2 = true;
        }
        else player2 = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //check if powerup were pickedup
    public void CheckPowerup()
    {        
        //check if player1 & player 2pickedup
        if (player1 ==false && player2 == false)
        {
            //change the number between stages
            Data.instance.StageNumber++;            
            //then load next level            
            lm.LoadLevel("_between_scenes");
        }        
    }

    public void SpawnPowerup()
    {
        //spawn random powerups and change text above them
        for (int i = 0; i < 3; i++)
        {
            if(spawnPos[i] != null)
            {
                //choose randomly between existing powerups
                int j = (int)Random.Range(0f, powerup.Length);
                //instantiate the powerup at spawn position
                Powerup pickup = (Powerup)Instantiate(powerup[i], spawnPos[i].position, Quaternion.identity);
                //change parent of the pickup to spawn position
                pickup.transform.parent = spawnPos[i];
            }
        }
        //посмотреть в enemy formation
    }

}
