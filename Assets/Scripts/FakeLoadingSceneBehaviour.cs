using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FakeLoadingSceneBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject LoadTextObject;
    [SerializeField] private GameObject PressAnyButtonText;
    [SerializeField] private TMP_Text LoadText;
    private bool Loaded;

    private void Start()
    {
        Invoke("FinishLoading", 4f);
        noDots();
    }

    private void FinishLoading()
    {
        Loaded = true;
        LoadTextObject.SetActive(false);
        PressAnyButtonText.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown && Loaded)
        {
            SceneManager.LoadScene("Main");
        }
    }



    private void noDots()
    {
        LoadText.text = "£adowanie";
        Invoke("oneDot", 0.5f);
    }

    private void oneDot()
    {
        LoadText.text = "£adowanie.";
        Invoke("twoDots", 0.5f);
    }

    private void twoDots()
    {
        LoadText.text = "£adowanie..";
        Invoke("threeDots", 0.5f);
    }

    private void threeDots()
    {
        LoadText.text = "£adowanie...";
        Invoke("noDots", 0.5f);
    }

}
