using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIDragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string category;
    public Vector2 boardPosition;
    public Vector2 characterPosition;
    public float snapThreshold = 50f;

    // Tracks equipped item per category
    private static Dictionary<string, UIDragDrop> equippedItems
        = new Dictionary<string, UIDragDrop>();

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(transform.localPosition, characterPosition);

        if (distance <= snapThreshold)
        {
            EquipItem();
        }
        else
        {
            ReturnToBoard();
        }
    }

    private void EquipItem()
    {
        // If something is already equipped in this category
        if (equippedItems.ContainsKey(category))
        {
            UIDragDrop oldItem = equippedItems[category];

            if (oldItem != null && oldItem != this)
            {
                oldItem.ReturnToBoard();
            }
        }

        // Equip this item
        transform.localPosition = characterPosition;

        equippedItems[category] = this;
    }

    private void ReturnToBoard()
    {
        transform.localPosition = boardPosition;

        // If this item was marked equipped, remove it
        if (equippedItems.ContainsKey(category) && equippedItems[category] == this)
        {
            equippedItems.Remove(category);
        }
    }
}