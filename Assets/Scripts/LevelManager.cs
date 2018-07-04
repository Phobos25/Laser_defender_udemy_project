using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string _name)
    {
        Debug.Log("Load level");
        SceneManager.LoadScene(_name);
    }

    public void QuitRequest()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }   
 
    public void LoadFirstTime()
    {
        Data.instance.StageNumber = 1;
        LoadLevel("_between_scenes");
    }


}
