
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{

    public GameObject[] characters;
    public Dropdown characterDropdown;

    void Start()
    {
        ShowCharacter(0);

        characterDropdown.onValueChanged.AddListener(ShowCharacter);
    }

    public void ShowCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        characters[index].SetActive(true);
    }
}
