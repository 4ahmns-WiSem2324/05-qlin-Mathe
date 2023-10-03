using System.Collections;
using UnityEngine;
using TMPro;

public class Teilbarkeit : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private int numberToCheck;
    private int roundsPlayed = 0;

    private void Start()
    {
        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        if (roundsPlayed >= 20)
        {
            EndGame();
            return;
        }

        numberToCheck = Random.Range(1, 101);
        numberText.text = "Durch welche Zahl ist " + numberToCheck + " teilbar?";
    }

    public void CheckDivisibility(int divisor)
    {
        if (roundsPlayed >= 20)
        {
            return;
        }

        if (numberToCheck % divisor == 0)
        {
            numberText.text = "Richtig! " + numberToCheck + " ist durch " + divisor + " teilbar.";
        }
        else
        {
            numberText.text = "Falsch! " + numberToCheck + " ist nicht durch " + divisor + " teilbar.";
        }

        roundsPlayed++;

        if (roundsPlayed >= 20)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(GenerateNextNumberAfterDelay());
        }
    }

    private IEnumerator GenerateNextNumberAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        GenerateRandomNumber();
    }

    private void EndGame()
    {
        numberText.text = "Geschafft!";

    }


}
