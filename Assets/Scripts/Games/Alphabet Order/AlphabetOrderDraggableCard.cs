using UnityEngine;
using UnityEngine.EventSystems;

public class AlphabetOrderDraggableCard : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private GameAPI gameAPI;
    public string parentName;

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
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        parentName = transform.parent.name;
    }

}
