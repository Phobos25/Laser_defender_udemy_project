using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public void onePlayer()
    {
        Data.instance.TwoPlayerEnabled = false;
        SceneManager.LoadScene(1);
    }

    public void twoPlayer()
    {
        Data.instance.TwoPlayerEnabled = true;        
        SceneManager.LoadScene(1);
    }

}
