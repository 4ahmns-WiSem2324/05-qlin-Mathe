using UnityEngine;
using TMPro;

public class Teilbarkeit : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI feedback;
    private int numberToCheck;
    public bool feedCheck;


    public AudioClip rightClip;
    public AudioClip wrongClip;
    public AudioSource audioSource;

    void Start()
    {
        GenerateRandomNumber();
    }

    public void Feedback(string b)
    {
        if(feedCheck)
        {
            feedback.text = "Begründung: " + b;
        }
    }

    public void GenerateRandomNumber()
    {
        feedCheck = false;
        feedback.text = "";
        numberToCheck = Random.Range(1, 1001);
        numberText.text = "Durch welche Zahl ist " + numberToCheck + " teilbar?";
        numberText.color = Color.black;
    }

    public void CheckDivisibility(int divisor)
    {

        if (numberToCheck % divisor == 0)
        {
            numberText.text = "Richtig! " + numberToCheck + " ist durch " + divisor + " teilbar.";
            numberText.color = Color.green;
            audioSource.PlayOneShot(rightClip);
            feedCheck = false;
        }
        else
        {
            numberText.text = "Falsch! " + numberToCheck + " ist nicht durch " + divisor + " teilbar.";
            numberText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            feedCheck = true;
        }
    }
}
