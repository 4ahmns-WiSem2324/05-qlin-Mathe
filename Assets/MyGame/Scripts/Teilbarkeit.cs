using UnityEngine;
using TMPro;

public class Teilbarkeit : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private int numberToCheck;

    void Start()
    {
        GenerateRandomNumber();
    }

    public void GenerateRandomNumber()
    {
        numberToCheck = Random.Range(1, 101);
        numberText.text = "Durch welche Zahl ist " + numberToCheck + " teilbar?";
        numberText.color = Color.black;
    }

    public void CheckDivisibility(int divisor)
    {

        if (numberToCheck % divisor == 0)
        {
            numberText.text = "Richtig! " + numberToCheck + " ist durch " + divisor + " teilbar.";
            numberText.color = Color.green;
        }
        else
        {
            numberText.text = "Falsch! " + numberToCheck + " ist nicht durch " + divisor + " teilbar.";
            numberText.color = Color.red;
        }
    }
}
