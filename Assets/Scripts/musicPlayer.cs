using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour {

    #region Variables
    static musicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;
	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start ()
    {
	    if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);

            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
	}

    void OnLevelWasLoaded(int _level)
    {
        Debug.Log("MusicPlayer: Loaded level " + _level);
        //stoping current music
        music.Stop();
        
        if (_level == 0)
        {
            //change playing clip
            music.clip = startClip;
        }
        if (_level == 1)
        {
            //change playing clip
            music.clip = gameClip;
        }
        if (_level == 2)
        {
            //change playing clip
            music.clip = endClip;
        }
        music.loop = true;
        //start playing again
        music.Play();        
    }
	
	#endregion
}
