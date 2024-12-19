using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Linq;
using System;

public class ItemSearch : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string input;

    [SerializeField] private List<string> words = new List<string>
            {
                "Miecz",
                "Scyzoryk",
                "Maczuga",
                "Nunczak",
                "Klon Trurla",
                "Nitro",
                "Olej",
            };
    [SerializeField]
    private List<string> words2 = new List<string>
            {
                "Miecz",
                "Scyzoryk",
                "Maczuga",
                "Nunczak",
                "Klon Trurla",
                "Nitro",
                "Olej",
            };
    [SerializeField] private List<string> outputList = new List<string> { };

    // Start is called before the first frame update
    void Start()
    {
        //dropdown.AddOptions(words);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        input = inputField.text;

        if(inputField.isFocused && inputField.text != "")
        {
            //dropdown.Show();
            //inputField.Select();
           // dropdown.AddOptions(outputList);
           // dropdown.RefreshShownValue();
        }
        else if (inputField.isFocused && inputField.text == "")
        {
            //dropdown.Hide();
            //inputField.Select();

        }


        var filteredWords = words.Where(word => word.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();

        string[] output = new string[filteredWords.Count + 1];
        
        for (int i = 0; i < filteredWords.Count; i++)
        {
            output[i] = filteredWords[i];
            outputList.Add(output[i]);
           
        }


        //if (dropdown.value == 0)
        //{
        //    //miecz
        //    //words.RemoveAt(0);
        //    //dropdown.AddOptions(words);
        //    //dropdown.RefreshShownValue();
        //}
        //else if (dropdown.value == 1)
        //{
        //    words.RemoveAt(1);
        //    dropdown.AddOptions(words);
        //    dropdown.RefreshShownValue();
        //    //scyzoryk
        //}
        //else if (dropdown.value == 2)
        //{
        //    //maczuga
        //    words.RemoveAt(2);
        //    dropdown.AddOptions(words);
        //    dropdown.RefreshShownValue();
        //}
        //else if (dropdown.value == 3)
        //{
        //    //scyzoryk
        //}
        //else if (dropdown.value == 4)
        //{
        //    //scyzoryk
        //}
        //else if (dropdown.value == 5)
        //{
        //    //scyzoryk
        //}
        //else if (dropdown.value == 1)
        //{
        //    //scyzoryk
        //}

    }
}
