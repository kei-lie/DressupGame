using UnityEngine;

public class CategoryChange : MonoBehaviour
{
    public GameObject Pony1;
    public GameObject Pony2;

    public string currentCategory = "Dresses";

    void Start()
    {
        ShowCategory(currentCategory);
    }

    GameObject GetActiveCharacter()
    {
        return Pony1.activeSelf ? Pony1 : Pony2;
    }

    public void ShowCategory(string categoryName)
    {
        currentCategory = categoryName;

        GameObject activeChar = GetActiveCharacter();
        UIDragDrop[] items = activeChar.GetComponentsInChildren<UIDragDrop>(true);

        foreach (UIDragDrop item in items)
        {
            bool isEquipped =
                Vector2.Distance((Vector2)item.transform.localPosition, item.characterPosition) < 1f;

            if (isEquipped || item.category == categoryName)
                item.gameObject.SetActive(true);
            else
                item.gameObject.SetActive(false);
        }
    }

    // ✅ Button-safe functions (NO string typing needed)

    public void ShowHats()
    {
        ShowCategory("Hats");
    }

    public void ShowDresses()
    {
        ShowCategory("Dresses");
    }

    public void ShowShoes()
    {
        ShowCategory("Shoes");
    }

    public void ShowAccessories()
    {
        ShowCategory("Accessories");
    }

    public void RefreshCategory()
    {
        ShowCategory(currentCategory);
    }

    public void ResetCharacter()
    {
        GameObject activeChar = GetActiveCharacter();
        UIDragDrop[] items = activeChar.GetComponentsInChildren<UIDragDrop>(true);

        foreach (UIDragDrop item in items)
        {
            item.transform.localPosition = (Vector3)item.boardPosition;

            item.gameObject.SetActive(item.category == currentCategory);
        }
    }
}