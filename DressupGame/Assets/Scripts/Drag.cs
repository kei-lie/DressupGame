using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Vector3 snapPosition;
    public float snapDistance = 50f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(transform.localPosition, snapPosition);

        if (distance < snapDistance)
        {
            transform.localPosition = snapPosition;
        }
        else
        {
            transform.localPosition = startPosition;
        }
    }
}