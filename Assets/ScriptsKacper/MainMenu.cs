using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("FakeLoadingScene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
