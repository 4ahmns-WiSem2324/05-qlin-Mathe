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
    private float correctAnswer;

    public AudioClip rightClip;
    public AudioClip wrongClip;
    public AudioSource audioSource;

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
                resultText.color = Color.green;
                audioSource.PlayOneShot(rightClip);

            }
            else
            {
                resultText.text = "Falsch!";
                resultText.color = Color.red;
                rightAnswerText.text = "Die richtige Antwort ist " + correctAnswer;
                audioSource.PlayOneShot(wrongClip);
            }
        }
    }

    public void GenerateRandomEquation()
    {
        number1 = Random.Range(1, 101);
        number2 = Random.Range(1, Mathf.Max(101 - number1, 2));

        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            correctAnswer = number1 + number2;
            equationText.text = number1 + " + " + number2 + " = ";
        }
        else if(rand == 1)
        {
            correctAnswer = number1 - number2;
            equationText.text = number1 + " - " + number2 + " = ";
        }
        else if(rand == 2)
        {
            correctAnswer = number1 * number2;
            equationText.text = number1 + " * " + number2 + " = ";
        }
        else
        {
            correctAnswer = number1 / number2;
            equationText.text = number1 + " / " + number2 + " = ";
        }

        answerInput.text = "";
        resultText.text = "";
        rightAnswerText.text = "";
    }

}
