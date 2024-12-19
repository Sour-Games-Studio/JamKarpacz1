using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InitializeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    private void Awake()
    {

        if (!PlayerPrefs.HasKey("Mvolume"))
        {
            PlayerPrefs.SetFloat("Mvolume", 1);
        }

        if (!PlayerPrefs.HasKey("Evolume"))
        {
            PlayerPrefs.SetFloat("Evolume", 1);
        }

        if (!PlayerPrefs.HasKey("Fullscreen"))
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }

        float volume = PlayerPrefs.GetFloat("Mvolume");
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);

        volume = PlayerPrefs.GetFloat("Evolume");
        mixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);

        int fulscreen = PlayerPrefs.GetInt("Fullscreen");
        if(fulscreen == 1)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}
