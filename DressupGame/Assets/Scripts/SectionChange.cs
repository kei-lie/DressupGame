using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterSections
{
    public GameObject character;   // The character GameObject
    public GameObject[] hats;      // Hats for this character
    public GameObject[] dresses;    // Shirts for this character
    public GameObject[] shoes;     // Pants for this character
    public GameObject[] other;
}

public class SectionChange : MonoBehaviour
{
    [Header("Character Setup")]
    public CharacterSections[] characters; // Assign all characters here
    public Dropdown characterDropdown;     // Dropdown to select character

    private CharacterSections currentCharacter;

    void Start()
    {
        if (characterDropdown != null)
            characterDropdown.onValueChanged.AddListener(ShowCharacter);

        ShowCharacter(0); // Show first character by default
    }

    // Called by dropdown
    public void ShowCharacter(int index)
    {
        if (characters == null || characters.Length == 0) return;
        if (index < 0 || index >= characters.Length) return;

        // Disable all characters
        foreach (var c in characters)
            c.character.SetActive(false);

        // Enable selected character
        currentCharacter = characters[index];
        currentCharacter.character.SetActive(true);

        // Show default section
        ShowSection("Hats");
    }

    // Called by buttons
    public void ShowSection(string sectionName)
    {
        if (currentCharacter == null) return;

        // First, disable all sections
        SetActiveArray(currentCharacter.hats, false);
        SetActiveArray(currentCharacter.dresses, false);
        SetActiveArray(currentCharacter.shoes, false);
        SetActiveArray(currentCharacter.other, false);

        // Enable the requested section
        switch (sectionName)
        {
            case "Hats":
                SetActiveArray(currentCharacter.hats, true);
                break;
            case "Dresses":
                SetActiveArray(currentCharacter.dresses, true);
                break;
            case "Shoes":
                SetActiveArray(currentCharacter.shoes, true);
                break;
            case "Other":
                SetActiveArray(currentCharacter.other, true);
                break;
            default:
                Debug.LogWarning("Section not found: " + sectionName);
                break;
        }
    }

    private void SetActiveArray(GameObject[] objects, bool state)
    {
        if (objects == null) return;
        foreach (var obj in objects)
            obj.SetActive(state);
    }
}