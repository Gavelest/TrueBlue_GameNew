using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{

    public GameObject objectToEnable;

    public string curPassword = "123";
    public string input;
    public TMP_Text displayText;

    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    void Start()
    {
        btnClicked = 0;
        numOfGuesses = curPassword.Length;


    }

    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if(input == curPassword)
            {
                Debug.Log("Correct Password");
                input = "";
                btnClicked = 0;


            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                btnClicked = 0;


            }

        }


    }

    public void KeypadScreen()
    {
        keypadScreen = true;

        
        objectToEnable.SetActive(true);
       

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C":
                input = "";
                btnClicked = 0;
                displayText.text = input.ToString();
                break;

            default:
                btnClicked++;
                input += valueEntered;
                displayText.text = input.ToString();
                break;

        }


    }

}
