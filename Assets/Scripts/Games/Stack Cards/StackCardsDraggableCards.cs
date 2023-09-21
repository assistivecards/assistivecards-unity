using UnityEngine;
using UnityEngine.EventSystems;

public class StackCardsDraggableCards : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public string parentName;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
            transform.SetParent(GameObject.Find("GamePanel").transform);
            transform.SetAsLastSibling();
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            Debug.Log("PointerDown");
            gameAPI.VibrateWeak();
            gameAPI.PlaySFX("Pickup");
            parentName = transform.parent.name;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp");
    }

}
