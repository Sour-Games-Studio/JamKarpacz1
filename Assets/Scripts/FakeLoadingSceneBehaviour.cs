using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeLoadingSceneBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject LoadText;
    [SerializeField] private GameObject PressAnyButtonText;
    private bool Loaded;

    private void Start()
    {
        Invoke("FinishLoading", 4f);
    }

    private void FinishLoading()
    {
        Loaded = true;
        LoadText.SetActive(false);
        PressAnyButtonText.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }

}
