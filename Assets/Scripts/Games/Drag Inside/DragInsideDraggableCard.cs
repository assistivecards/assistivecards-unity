using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragInsideDraggableCard : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IBeginDragHandler
{
    private GameObject targetArea;
    private GameAPI gameAPI;
    public bool isAdded = false;

    void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        targetArea = GameObject.Find("TargetArea");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        transform.SetParent(GameObject.Find("GamePanel").transform);
        transform.SetAsLastSibling();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetArea.GetComponent<DragInsideMatchDetection>().CheckCardsInside();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        gameAPI.PlaySFX("Pickup");
    }
}
