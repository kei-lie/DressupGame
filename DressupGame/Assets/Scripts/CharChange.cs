using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharChange : MonoBehaviour
{
    public GameObject Pony1;
    public GameObject Pony2;
    public CategoryChange Cat;

    public Slider widthSlider;
    public Slider heightSlider;

    public TMP_Dropdown characterDropdown;

    private void Start()
    {
        // Make sure dropdown is connected
        if (characterDropdown != null)
        {
            characterDropdown.onValueChanged.AddListener(ChangeCharacter);
        }

        // Force correct character at start
        ChangeCharacter(characterDropdown.value);
    }

    public void ChangeCharacter(int index)
    {
        Pony1.SetActive(index == 0);
        Pony2.SetActive(index == 1);

        GameObject activeChar = GetActiveCharacter();

        if (Cat != null)
            Cat.ShowCategory(Cat.currentCategory);

        // Reset sliders
        if (widthSlider != null) widthSlider.value = 1f;
        if (heightSlider != null) heightSlider.value = 1f;

        // Reset scale
        if (activeChar != null)
            activeChar.transform.localScale = Vector3.one;
    }

    public void AdjustWidth(float value)
    {
        GameObject activeChar = GetActiveCharacter();
        if (activeChar == null) return;

        Vector3 scale = activeChar.transform.localScale;
        scale.x = value;
        activeChar.transform.localScale = scale;
    }

    public void AdjustHeight(float value)
    {
        GameObject activeChar = GetActiveCharacter();
        if (activeChar == null) return;

        Vector3 scale = activeChar.transform.localScale;
        scale.y = value;
        activeChar.transform.localScale = scale;
    }

    private GameObject GetActiveCharacter()
    {
        if (Pony1.activeSelf) return Pony1;
        if (Pony2.activeSelf) return Pony2;
        return null;
    }
}