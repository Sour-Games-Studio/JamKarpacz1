using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Windows;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private PlayerMovement player;
    
    // Start is called before the first frame update
    void Start()
    {
        inputField.gameObject.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        text1.text = "";
        text2.text = "";
        text3.text = "";
    }
    public static List<string> words = new List<string>
            {
                "Maczuga",
                "Miecz",
                "Scyzoryk",
                "Nunczak",
                "Naostrzona kredka",
                "Ostrze",
                "Chwytak",
                "Nitro",
                "Silnik",
                "Paliwo",
                "Wiatrak",
                "Opona",
                "Czerwona kredka",
                "Bateria",
                "Akumulator",
                "Olej",
                "Wtyczka",
                "Trybik",
                "Zestaw naprawczy",
                "Smar",
                "Zielona kredka",
                "Antena",
                "Klon Trurla"
            };

    // Update is called once per frame
    void Update()
    {
        WishMachine();

        //inicjacja maszyny

    }
    public void WishMachineOnOff(bool onOff)
    {
        if(onOff)
        {
            player.canMove = false;
            inputField.gameObject.SetActive(true);
        }
        else if(!onOff)
        {
            player.canMove = true;
            inputField.gameObject.SetActive(false);
        }
    }
    public void WishMachine()
    { 
        string input;
        if (inputField.text != "")
        {
            input = inputField.text;

            var filteredWords = words.Where(word => word.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();

            for (int i = 0; i < filteredWords.Count; i++)
            {
                Debug.Log(filteredWords.Count);
                if (filteredWords.Count == 0)
                {
                    Debug.Log(filteredWords.Count);
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    text1.text = filteredWords[0].ToString();
                    text2.text = "";
                    text3.text = "";
                }
                if (filteredWords.Count == 1)
                {
                    Debug.Log(filteredWords.Count);
                    button1.SetActive(true);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    text1.text = filteredWords[0].ToString();
                    text3.text = "";
                    text2.text = "";

                }
                if (filteredWords.Count == 2)
                {
                    Debug.Log(filteredWords.Count);
                    button1.SetActive(true);
                    button2.SetActive(true);
                    button3.SetActive(false);
                    text1.text = filteredWords[0].ToString();
                    text2.text = filteredWords[1].ToString();
                    text3.text = "";
                }
                if (filteredWords.Count == 3)
                {
                    Debug.Log(filteredWords.Count);
                    button1.SetActive(true);
                    button2.SetActive(true);
                    button3.SetActive(true);
                    text1.text = filteredWords[0].ToString();
                    text2.text = filteredWords[1].ToString();
                    text3.text = filteredWords[2].ToString();

                }
            }
        }
        else if (inputField.text == "")
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            text1.text = "";
            text2.text = "";
            text3.text = "";
        }
    }

    public void Button1()
    {
        if(text1.text == "Miecz" || text1.text == "Scyzoryk" || text1.text == "Maczuga" || text1.text == "Nunczak" || text1.text == "Naostrzona kredka" || text1.text == "Ostrze" || text1.text == "Chwytak")
        {
            player.GetComponent<MeleeAttack>().attackDamage += 2f;
            player.GetComponent<RangedAttack>().attackDamage++;
            PlayerPrefs.SetFloat("meleeAttackDamage", player.GetComponent<MeleeAttack>().attackDamage);
            PlayerPrefs.SetFloat("rangedAttackDamage", player.GetComponent<RangedAttack>().attackDamage);
            Debug.LogWarning("guzik dziala");
            words.Remove(text1.text);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if(text1.text == "Nitro" || text1.text == "Silnik" || text1.text == "Paliwo" || text1.text == "Wiatrak" || text1.text == "Opona"|| text1.text == "Czerwona kredka" || text1.text == "Bateria" || text1.text == "Akumulator")
        {
            player.moveSpeed++;
            PlayerPrefs.SetFloat("moveSpeed", player.moveSpeed);
            words.Remove(text1.text);
        }
        else if (text1.text == "Olej" || text1.text == "Wtyczka" || text1.text == "Trybik" || text1.text == "Zestaw Naprawczy" || text1.text == "Smar" || text1.text == "Zielona kredka" || text1.text == "Antena" || text1.text == "Klon Trurla")
        {
            player.health++;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text1.text);
        }
        else if (text1.text == "Bomba" || text1.text == "Mina" || text1.text == "Granat" || text1.text == "Woda" || text1.text == "Piasek" || text1.text == "Rdza")
        {
            player.health--;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text1.text);
        }

        inputField.text = "";
        WishMachineOnOff(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Button2()
    {
        if (text2.text == "Miecz" || text2.text == "Scyzoryk" || text2.text == "Maczuga" || text2.text == "Nunczak" || text2.text == "Naostrzona kredka" || text2.text == "Ostrze" || text2.text == "Chwytak")
        {
            player.GetComponent<MeleeAttack>().attackDamage += 2f;
            player.GetComponent<RangedAttack>().attackDamage++;
            PlayerPrefs.SetFloat("meleeAttackDamage", player.GetComponent<MeleeAttack>().attackDamage);
            PlayerPrefs.SetFloat("rangedAttackDamage", player.GetComponent<RangedAttack>().attackDamage);
            words.Remove(text2.text);
        }
        else if (text2.text == "Nitro" || text2.text == "Silnik" || text2.text == "Paliwo" || text2.text == "Wiatrak" || text2.text == "Opona"|| text2.text == "Czerwona kredka" || text2.text == "Bateria" || text2.text == "Akumulator")
        {
            player.moveSpeed++;
            PlayerPrefs.SetFloat("moveSpeed", player.moveSpeed);
            words.Remove(text2.text);
        }
        else if (text2.text == "Olej" || text2.text == "Wtyczka" || text2.text == "Trybik" || text2.text == "Zestaw Naprawczy" || text2.text == "Smar" || text2.text == "Zielona kredka" || text2.text == "Antena" || text2.text == "Klon Trurla")
        {
            player.health++;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text2.text);
        }
        else if (text2.text == "Bomba" || text2.text == "Mina" || text2.text == "Granat" || text2.text == "Woda" || text2.text == "Piasek" || text2.text == "Rdza")
        {
            player.health--;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text2.text);
        }

        inputField.text = "";
        WishMachineOnOff(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Button3()
    {
        if (text3.text == "Miecz" || text3.text == "Scyzoryk" || text3.text == "Maczuga" || text3.text == "Nunczak" || text3.text == "Naostrzona kredka" || text3.text == "Ostrze" || text3.text == "Chwytak")
        {
            player.GetComponent<MeleeAttack>().attackDamage += 2f;
            player.GetComponent<RangedAttack>().attackDamage++;
            PlayerPrefs.SetFloat("meleeAttackDamage", player.GetComponent<MeleeAttack>().attackDamage);
            PlayerPrefs.SetFloat("rangedAttackDamage", player.GetComponent<RangedAttack>().attackDamage);
            words.Remove(text3.text);
        }
        else if (text3.text == "Nitro" || text3.text == "Silnik" || text3.text == "Paliwo" || text3.text == "Wiatrak" || text3.text == "Opona"|| text3.text == "Czerwona kredka" || text3.text == "Bateria" || text3.text == "Akumulator")
        {
            player.moveSpeed++;
            PlayerPrefs.SetFloat("moveSpeed", player.moveSpeed);
            words.Remove(text3.text);
        }
        else if (text3.text == "Olej" || text3.text == "Wtyczka" || text3.text == "Trybik" || text3.text == "Zestaw Naprawczy" || text3.text == "Smar" || text3.text == "Zielona kredka" || text3.text == "Antena" || text3.text == "Klon Trurla")
        {
            player.health++;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text3.text);
        }
        else if (text3.text == "Bomba" || text3.text == "Mina" || text3.text == "Granat" || text3.text == "Woda" || text3.text == "Piasek" || text3.text == "Rdza")
        {
            player.health--;
            PlayerPrefs.SetFloat("health", player.health);
            words.Remove(text3.text);
        }

        inputField.text = "";
        WishMachineOnOff(false);

    }
}
