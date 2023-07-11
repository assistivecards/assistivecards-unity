using UnityEngine;
using UnityEngine.EventSystems;

public class AlphabetOrderDraggableCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        transform.SetParent(GameObject.Find("GamePanel").transform);
        transform.SetAsLastSibling();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        Debug.Log("PointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp");
    }

}
