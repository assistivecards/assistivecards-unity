using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatchPairsDraggablePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
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
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            gameAPI.VibrateWeak();
            gameAPI.PlaySFX("Pickup");
            transform.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            transform.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
