using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    #region Variables
    public Text text;

    //point counter variable
    public static int points;
    //keeps number of wave numbers in all scenes 
    public static int waveNumbers = 2;
	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start ()
    {
        //check if there is Text component
        if (!text)
        {
            text = GetComponent<Text>();
        }
        Reset();
    }

    #endregion

    #region ScoreKeeper
    public void Score(int _points)
    {
        //adds points to the static variable
        points += _points;
        //update the points counter
        text.text = points.ToString();
    }

    public void Reset()
    {
        text.text = points.ToString();
    }
    #endregion 

}
