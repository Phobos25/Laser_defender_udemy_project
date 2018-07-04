using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthKeeper : MonoBehaviour {

    #region Variables

    public Text healthText;      
	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start ()
    {
        //check if Text component is set in editor
        if (!healthText)
        {
            //if not get component of the Text component
            healthText = GetComponent<Text>();
        }            
	}	
	#endregion
    //the method shows player health
    public void DisplayHealth(float _health)
    {
        healthText.text = _health.ToString();
    } 

}
