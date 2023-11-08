using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectTouchWordHunt : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private BoardGeneratorWordHunt boardGenerator;
    [SerializeField] private GameObject touchDetectionObject;
    public Color[] colors;
    public Color currentColor;
    public bool isDragging;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        isDragging = true;
        touchDetectionObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragEndPosition = eventData.position;
        touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        touchDetectionObject.transform.position = touchPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        touchDetectionObject.SetActive(false);
        boardGenerator.Invoke("CheckWord", 0.5f);
    }
}
