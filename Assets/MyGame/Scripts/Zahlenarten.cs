using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Zahlenarten : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI feedbackText;
    public Toggle naturalNumberToggle;
    public Toggle wholeNumberToggle;
    public Toggle rationalNumberToggle;
    private bool selectionMade = false;

    public float numberToDetect;
    public int decide;

    public AudioClip rightClip;
    public AudioClip wrongClip;
    public AudioSource audioSource;

    private void Start()
    {
        numberToDetect = Random.Range(0.01f, 101.9f);
        numberText.text = numberToDetect.ToString();
        naturalNumberToggle.isOn = false;
        wholeNumberToggle.isOn = false;
        rationalNumberToggle.isOn = false;
    }
    private void Update()
    {

        if (naturalNumberToggle.isOn)
        {
            wholeNumberToggle.isOn = false;
            rationalNumberToggle.isOn = false;
            selectionMade = true;
        }
        else if(rationalNumberToggle.isOn)
        {
            wholeNumberToggle.isOn = false;
            naturalNumberToggle.isOn = false;
            selectionMade = true;
        }
        else if (wholeNumberToggle.isOn)
        {
            naturalNumberToggle.isOn = false;
            rationalNumberToggle.isOn = false;
            selectionMade = true;
        }
        else
        {
            selectionMade = false;
            feedbackText.text = "Wähle eins aus";
        }
    }

    public void GenerateNumber()
    {
        feedbackText.color = Color.black;
        feedbackText.text = "Es handelt sich um eine ...";
        decide = Random.Range(0, 2);
        if(decide == 0)
        {
            numberToDetect = Random.Range(1, 101);
        }
        else
        {
            numberToDetect = Random.Range(1f, 101f);
        }
        numberText.text = numberToDetect.ToString();
    }

    public void CheckDecision()
    {
        if(selectionMade == true)
        {
            if (naturalNumberToggle.isOn)
            {
                DetectNumberTypeNatural(numberToDetect);
            }
            else if (wholeNumberToggle.isOn)
            {
                DetectNumberTypeInteger(numberToDetect);
            }
            else
            {
                DetectNumberTypeDecimal(numberToDetect);
            }
        }
        else
        {
            feedbackText.color = Color.red;
        }
    }

    void DetectNumberTypeNatural(float number)
    {
        if (IsNaturalNumber(number))
        {
            feedbackText.text = "Richtig " + number + " ist eine natürliche Zahl.";
            feedbackText.color = Color.green;
            audioSource.PlayOneShot(rightClip);
            return;
        }
        else if(IsInteger(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine ganze Zahl.";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else if(IsDecimalNumber(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine dezimal Zahl";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else
        {
            numberText.text = number + " ist keine der bekannten Zahlentypen.";
        }
    }

    void DetectNumberTypeInteger(float number)
    {
        if (IsInteger(number))
        {
            feedbackText.text = "Richtig " + number + " ist eine ganze Zahl.";
            feedbackText.color = Color.green;
            audioSource.PlayOneShot(rightClip);
            return;
        }
        else if (IsNaturalNumber(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine natürliche Zahl.";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else if (IsDecimalNumber(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine dezimal Zahl";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else
        {
            numberText.text = number + " ist keine der bekannten Zahlentypen.";
        }

    }

    void DetectNumberTypeDecimal(float number)
    {
        if (IsDecimalNumber(number))
        {
            feedbackText.text = "Richtig " + number + " ist eine Dezimalzahl.";
            feedbackText.color = Color.green;
            audioSource.PlayOneShot(rightClip);
            return;
        }
        else if (IsInteger(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine ganze Zahl.";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else if (IsNaturalNumber(number))
        {
            feedbackText.text = "Falsch " + number + " ist eine natürliche Zahl";
            feedbackText.color = Color.red;
            audioSource.PlayOneShot(wrongClip);
            return;
        }
        else
        {
            feedbackText.text = number + " ist keine der bekannten Zahlentypen.";
        }
    }

    bool IsNaturalNumber(float number)
    {
        if (number >= 0 && Mathf.Approximately(number, Mathf.Floor(number)))
        {
            return true;
        }
        return false;
    }

    bool IsInteger(float number)
    {
        if (Mathf.Approximately(number, Mathf.Floor(number)))
        {
            return true;
        }
        return false;
    }

    bool IsDecimalNumber(float number)
    {
        if (!IsInteger(number))
        {
            return true;
        }
        return false;
    }
}

