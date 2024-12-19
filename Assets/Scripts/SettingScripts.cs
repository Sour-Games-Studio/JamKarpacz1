using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingScripts : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private bool isForMusic;
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField] private bool AmIMusic;

    public void ChangedVolume(float volume)
    {
        if (isForMusic)
        {
            mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("Mvolume", volume);
        }
        else
        {
            mixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("Evolume", volume);
        }
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if(AmIMusic)
        {
            if (isForMusic)
            {
                float volume = PlayerPrefs.GetFloat("Mvolume");
                mySlider.value = volume;
            }
            else
            {
                float volume = PlayerPrefs.GetFloat("Evolume");
                mySlider.value = volume;
            }
        }
        else
        {
            int fullscreen = PlayerPrefs.GetInt("Fullscreen");
            if (fullscreen == 0)
            {
                myToggle.isOn = false;
            }
            else
            {
                myToggle.isOn = true;
            }
        }
    }

    public void ToggleFullScreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
            Screen.fullScreen = true;
            print("Is now Fullscreen");
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
            Screen.fullScreen = false;
            print("Is now windowed");
        }
        PlayerPrefs.Save();
    }
}
