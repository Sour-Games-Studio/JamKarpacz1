using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource ASS;

    public void UIClick()
    {
        ASS.Play();
    }
}
