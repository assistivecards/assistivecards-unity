using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] GameObject gamePanel;
    GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var bounds = gamePanel.GetComponent<BoxCollider2D>().bounds;
        // Debug.Log("rt: " + bounds.min.x + " " + bounds.max.x + " " + bounds.min.y + " " + bounds.max.y);
        // Debug.Log(transform.position.x + " " + transform.position.y);
        transform.position = new Vector2(Mathf.Clamp(eventData.position.x, bounds.min.x + 145, bounds.max.x - 145), Mathf.Clamp(eventData.position.y, bounds.min.y + 100, bounds.max.y - 100));

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DetectMatch.isPointerUp = false;
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        transform.position = eventData.position;
    }
}
