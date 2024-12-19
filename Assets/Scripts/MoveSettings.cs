using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveSettings : MonoBehaviour
{
    private Button lastPressedButton;
    private TMP_Text lastUsedText;
    private GameObject lastSection;

    [SerializeField] private List<Button> Buttons;
    [SerializeField] private List<TMP_Text> Texts;
    [SerializeField] private List<GameObject> Sections;

    [SerializeField] private Sprite ActiveSprite;
    [SerializeField] private Sprite InactiveSprite;


    private void Start()
    {
        lastPressedButton = Buttons[0];
        lastUsedText = Texts[0];
        lastSection = Sections[0];

        Buttons[0].interactable = false;
        Texts[0].color = Color.white;
        Sections[0].SetActive(true);
        Buttons[0].image.sprite = ActiveSprite;
    }

    public void SteeringClick()
    {
        lastUsedText.color = Color.black;
        lastPressedButton.interactable = true;
        lastSection.SetActive(false);
        lastPressedButton.image.sprite = InactiveSprite;

        Buttons[0].interactable = false;
        Texts[0].color = Color.white;
        Sections[0].SetActive(true);
        Buttons[0].image.sprite = ActiveSprite;

        lastPressedButton = Buttons[0];
        lastUsedText = Texts[0];
        lastSection = Sections[0];
    }
    public void GraphicClick()
    {
        lastUsedText.color = Color.black;
        lastPressedButton.interactable = true;
        lastSection.SetActive(false);
        lastPressedButton.image.sprite = InactiveSprite;

        Buttons[1].interactable = false;
        Texts[1].color = Color.white;
        Sections[1].SetActive(true);
        Buttons[1].image.sprite = ActiveSprite;

        lastPressedButton = Buttons[1];
        lastUsedText = Texts[1];
        lastSection = Sections[1];
    }
    public void AudioClick()
    {
        lastUsedText.color = Color.black;
        lastPressedButton.interactable = true;
        lastSection.SetActive(false);
        lastPressedButton.image.sprite = InactiveSprite;

        Buttons[2].interactable = false;
        Texts[2].color = Color.white;
        Sections[2].SetActive(true);
        Buttons[2].image.sprite = ActiveSprite;

        lastPressedButton = Buttons[2];
        lastUsedText = Texts[2];
        lastSection = Sections[2];
    }
}
