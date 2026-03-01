using UnityEngine;
using TMPro;
public class AgeName : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField birthYearInput;
    public TMP_Text resultText;

    public void CalculateAge()
    {
        if (int.TryParse(birthYearInput.text, out int birthYear))
        {
            int age = System.DateTime.Now.Year - birthYear;
            resultText.text = nameInput.text +
                              " is " + age + " years old!!";
        }
        else
        {
            resultText.text = "Enter a valid birth year!";
        }
    }
}
