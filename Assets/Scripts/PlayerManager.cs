using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public Text player2HealthText;
    public Transform player2Sprite;

    private bool CheckIfPlayerEnabled;
	#region Unity Methods

	// Use this for initialization
	void Awake ()
    {
        //check if one or two player mode is enabled
        if (Data.instance.TwoPlayerEnabled)
        {
            //if 2 player mode is enabled then create 2 player ships
            Instantiate(player1, player1.transform.position, Quaternion.identity);
            Instantiate(player2, player2.transform.position, Quaternion.identity);
            //enable 2nd player health and image near health 
            Enable2ndPlayer();
        }
        else
        {
            //if only 1 player mode is enabled
            Instantiate(player1, player1.transform.position, Quaternion.identity);
            //hide 2nd player health and image near health
            Disable2ndPlayer();
        }

    }

    #endregion

    #region SecondPlayerMethods
    void Enable2ndPlayer()
    {
        //chech if player 2 text and sprite are not equal to null
        if (player2HealthText && player2Sprite)
        {
            player2HealthText.gameObject.SetActive(true);
            player2Sprite.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Player 2 heath text and sprite was not set as an instance in " + gameObject.name);
        }
    }
    
    //disable 2nd player 
    void Disable2ndPlayer()
    {
        //chech if player 2 text and sprite are not equal to null
        if (player2HealthText && player2Sprite)
        {
            //if player 2 is not enabled hide player 2 health and image
            player2HealthText.gameObject.SetActive(false);
            player2Sprite.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Player 2 heath text and sprite was not set as an instance in " + gameObject.name);
        }
    }
    #endregion 
}
