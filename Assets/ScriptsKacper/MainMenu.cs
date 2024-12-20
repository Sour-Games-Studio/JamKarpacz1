using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource AS;
    public void StartGame()
    {
        StartCoroutine(StartCo());
    }
    private IEnumerator StartCo()
    {
        AS.Play();
        while (AS.isPlaying == true)
        {
            yield return null;
        }

        SceneManager.LoadScene("FakeLoadingScene");
    }
    public void Settings()
    {
        StartCoroutine(StartSe());
    }
    private IEnumerator StartSe()
    {
        AS.Play();
        while (AS.isPlaying == true)
        {
            yield return null;
        }

        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        StartCoroutine(StartCr());
    }
    private IEnumerator StartCr()
    {
        AS.Play();
        while (AS.isPlaying == true)
        {
            yield return null;
        }

        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        StartCoroutine(StartQu());
    }
    private IEnumerator StartQu()
    {
        AS.Play();
        while (AS.isPlaying == true)
        {
            yield return null;
        }

        print("QUIT");
        Application.Quit();
    }

    public void Return()
    {
        StartCoroutine(StartRe());
    }
    private IEnumerator StartRe()
    {
        AS.Play();
        while (AS.isPlaying == true)
        {
            yield return null;
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySound()
    {
        if (!AS.isPlaying)
        {
            AS.Play();
        }
    }
}
