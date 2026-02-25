using UnityEngine;
using TMPro;
using System;

public class Name : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField yearInput;
    public TMP_Text resultText;


    public void CalculateAgeAndDisplay()
    {
        string charName = nameInput.text;

        if (int.TryParse(yearInput.text, out int birthYear))
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            resultText.text = $"{charName} is {age} years old!";
        }
        else
        {
            resultText.text = "Please add a valid year.";
        }
    }
}