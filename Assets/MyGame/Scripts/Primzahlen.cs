using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Primzahlen : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public Button yesButton;
    public Button noButton;
    private int randomNumber;
    private bool isPrime;
    private int rounds = 0;

    private void Start()
    {
        yesButton.onClick.AddListener(CheckIsPrime);
        noButton.onClick.AddListener(CheckIsNotPrime);

        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        if (rounds < 20)
        {
            rounds++;
            randomNumber = Random.Range(1, 101);
            isPrime = IsPrime(randomNumber);

            numberText.text = "Ist " + randomNumber + " eine Primzahl?";
        }
        else
        {
            EndGame();
        }
    }

    private void CheckIsPrime()
    {
        if (isPrime)
        {
            numberText.text = "Richtig! " + randomNumber + " ist eine Primzahl.";
        }
        else
        {
            numberText.text = "Falsch! " + randomNumber + " ist keine Primzahl.";
        }

        StartCoroutine(ShowNextNumberAfterDelay(3f));
    }

    private void CheckIsNotPrime()
    {
        if (!isPrime)
        {
            numberText.text = "Richtig! " + randomNumber + " ist keine Primzahl.";
        }
        else
        {
            numberText.text = "Falsch! " + randomNumber + " ist eine Primzahl.";
        }

        StartCoroutine(ShowNextNumberAfterDelay(3f));
    }

    private void EndGame()
    {
        numberText.text = "Geschafft!";
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

    private IEnumerator ShowNextNumberAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        GenerateRandomNumber();
    }
}
