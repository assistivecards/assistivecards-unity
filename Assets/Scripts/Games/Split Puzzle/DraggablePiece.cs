using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] GameObject gamePanel;
    private GameAPI gameAPI;
    // public string parentName;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // transform.SetParent(GameObject.Find("GamePanel").transform);
        // transform.SetSiblingIndex(10);
        var bounds = gamePanel.GetComponent<BoxCollider2D>().bounds;
        transform.position = new Vector2(Mathf.Clamp(eventData.position.x, bounds.min.x + 145, bounds.max.x - 145), Mathf.Clamp(eventData.position.y, bounds.min.y + 155, bounds.max.y - 100));

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // parentName = transform.parent.name;
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        transform.position = eventData.position;
    }
}
