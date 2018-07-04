using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenScenes : MonoBehaviour {

    public LevelManager lm;
    public Text text;
    public float timeToLoad = 5f;
    private float timer;

    // Use this for initialization
	void Start () {
        ChangeText(Data.instance.StageNumber);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timer += Time.deltaTime;
        if(timer >= timeToLoad)
        {
            LoadNextLevel(Data.instance.StageNumber);
        }

        if (Input.anyKey)
        {
            LoadNextLevel(Data.instance.StageNumber);
        }
	}

    void LoadNextLevel(int _level)
    {
        if (_level == 1)
        {
            lm.LoadLevel("_Level_01");
        }
        if (_level == 2)
        {
            lm.LoadLevel("_Level_02");
        }

        if(_level == 3)
        {
            lm.LoadLevel("_Level_03");
        } 
        
        if (_level==0)
        {
            lm.LoadLevel("_Middle_of_Nowhere");
        }
    }

    public void ChangeText(int _number)
    {
        text.text = "Stage "+ _number;
    }
}
