using UnityEngine;
using System.Collections;

public class ShootSoundController : MonoBehaviour {

    #region Variables

    public AudioClip shootSound;
    public float maxVol = 0.8f;
    public float minVol = 0.3f;

    private AudioSource source;

    #endregion

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect()
    {
        maxVol = (SettingsMenu.MasterVolume+80)/80;
        minVol = maxVol * 0.5f;
        // choose a value between max volume and min volume randomly
        // this way every shot will have different volume
        float vol = Random.Range(minVol, maxVol);
        //play sound effect        
        AudioSource.PlayClipAtPoint(shootSound, transform.position, vol);
    }
}
