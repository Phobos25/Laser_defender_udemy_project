using UnityEngine;
using UnityEngine.UI;

public class SettingsPlayers : MonoBehaviour
{
    public Button b1Player;
    public Button b2Players; 

    public void ChooseOnePlayer()
    {
        //disable 2 players mode
        Data.instance.TwoPlayerEnabled = false;
        //make the button not interactable
        b1Player.interactable = false;
        b2Players.interactable = true;
    }

    public void ChooseTwoPlayers()
    {
        //enable 2 players mode
        Data.instance.TwoPlayerEnabled = true;
        //make the button not interactable
        b1Player.interactable = true;
        b2Players.interactable = false;
    }
}
