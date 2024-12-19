using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
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
