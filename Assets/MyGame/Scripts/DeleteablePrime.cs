using UnityEngine;
using TMPro;
using System;

public class DeleteablePrime : MonoBehaviour
{
    public TMP_InputField numberInputText;
    public TextMeshProUGUI feedbackText;
    public int numberInput;
    private bool isPrime;

    public int primeNumCounter;
    private void Start()
    {
        feedbackText.text = "Bitte tippe eine Primzahl ein";
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

        if (!isPrime)
        {
            feedbackText.text = "Ist keine Primzahl bitte tippe eine Primzahl ein";
            feedbackText.color = Color.red;
        }
        else
        {
            primeNumCounter++;
            PrimeCounter();
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

    public void PrimeCounter()
    {
        string numberString = numberInput.ToString();
        int numLength = numberString.Length;

        for (int i = 0; i < numLength; i++)
        {
            for (int j = 0; j < numLength; j++)
            {
                if (i == j)
                    continue;

                string subNumberString = numberString.Remove(j, 1);
                int subNumber = int.Parse(subNumberString);

                if (IsPrime(subNumber))
                {
                    primeNumCounter++;
                }
            }
        }

        feedbackText.text = "Es gab " + primeNumCounter + " Primzahle/n";
        feedbackText.color = Color.black;
        primeNumCounter = 0;
    }
}
