using System.Collections;
using UnityEngine;
using TMPro;

public class Rechenarten : MonoBehaviour
{
    public TextMeshProUGUI equationText;
    public TextMeshProUGUI rightAnswerText;
    public TMP_InputField answerInput;
    public TextMeshProUGUI resultText;
    private int number1;
    private int number2;
    private int correctAnswer;
    private int roundsPlayed = 0;

    private void Start()
    {
        GenerateRandomEquation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckAnswer();
        }
    }

    public void CheckAnswer()
    {
        int playerAnswer;

        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                resultText.text = "Richtig!";

            }
            else
            {
                resultText.text = "Falsch!";
                rightAnswerText.text = "Die richtige Antwort ist " + correctAnswer;
            }


            StartCoroutine(GenerateNextEquationAfterDelay());
        }
    }

    private IEnumerator GenerateNextEquationAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        roundsPlayed++;

        if (roundsPlayed >= 20)
        {
            EndGame();
        }
        else
        {
            GenerateRandomEquation();
        }
    }

    private void GenerateRandomEquation()
    {
        number1 = UnityEngine.Random.Range(1, 101);
        number2 = UnityEngine.Random.Range(1, Mathf.Max(101 - number1, 2));

        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            correctAnswer = number1 + number2;
            equationText.text = number1 + " + " + number2 + " = ";
        }
        else
        {
            correctAnswer = number1 - number2;
            equationText.text = number1 + " - " + number2 + " = ";
        }

        answerInput.text = "";
        resultText.text = "";
        rightAnswerText.text = "";
    }

    private void EndGame()
    {
        resultText.text = "Geschafft!";
    }

}
