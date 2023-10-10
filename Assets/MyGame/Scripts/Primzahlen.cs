using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Primzahlen : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TMP_InputField numberInputText;
    public TextMeshProUGUI feedbackText;
    public int numberInput;
    public Button yesButton;
    public Button noButton;
    private int randomNumber;
    private bool isPrime;

    private void Start()
    {
        yesButton.onClick.AddListener(CheckIsPrime);
        noButton.onClick.AddListener(CheckIsNotPrime);

        GenerateRandomNumber();
        feedbackText.text = "Schreib eine Nummer rein";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && numberInputText.text != "")
        {
            try
            {
                CheckInputNumber();
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }
    }
    public void CheckInputNumber()
    {
        numberInput = int.Parse(numberInputText.text);
        isPrime = IsPrime(numberInput);

        if (isPrime)
        {
            feedbackText.text = "Ist eine Primzahl";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Ist keine Primzahl";
            feedbackText.color = Color.red;
        }
    }
    public void GenerateRandomNumber()
    {
        numberText.color = Color.white;
        randomNumber = UnityEngine.Random.Range(1, 101);
        isPrime = IsPrime(randomNumber);

        numberText.text = "Ist " + randomNumber + " eine Primzahl?";
    }

    public void CheckIsPrime()
    {
        if (isPrime)
        {
            numberText.text = "Richtig! " + randomNumber + " ist eine Primzahl.";
            numberText.color = Color.green;
        }
        else if (!isPrime)
        {
            numberText.text = "Falsch! " + randomNumber + " ist keine Primzahl.";
            numberText.color = Color.red;
        }
    }

    private void CheckIsNotPrime()
    {
        if (!isPrime)
        {
            numberText.text = "Richtig! " + randomNumber + " ist keine Primzahl.";
            numberText.color = Color.green;
        }
        else
        {
            numberText.text = "Falsch! " + randomNumber + " ist eine Primzahl.";
            numberText.color = Color.red;
        }
    }

    private bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Mathf.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
