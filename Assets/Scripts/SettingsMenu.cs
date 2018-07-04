using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public static float MasterVolume;

    public Slider slider;

    public void SetVolume(float _volume)
    {
        audioMixer.SetFloat("volume", _volume);
        MasterVolume = _volume;
    }

    private void Start()
    {
        slider.value = MasterVolume;
    }
}
