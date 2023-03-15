using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PiecePuzzleDraggablePiece : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private void OnEnable()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 1;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
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
