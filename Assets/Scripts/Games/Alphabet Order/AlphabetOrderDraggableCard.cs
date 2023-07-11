using UnityEngine;
using UnityEngine.EventSystems;

public class AlphabetOrderDraggableCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        transform.SetParent(GameObject.Find("GamePanel").transform);
        transform.SetAsLastSibling();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp");
    }

}
