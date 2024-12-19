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
        LoadText = LoadTextObject.GetComponent<TMP_Text>();
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
        LoadText.text = "Loading";
        Invoke("oneDot", 0.5f);
    }

    private void oneDot()
    {
        LoadText.text = "Loading.";
        Invoke("twoDots", 0.5f);
    }

    private void twoDots()
    {
        LoadText.text = "Loading..";
        Invoke("threeDots", 0.5f);
    }

    private void threeDots()
    {
        LoadText.text = "Loading...";
        Invoke("noDots", 0.5f);
    }

}
