using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
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
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // parentName = transform.parent.name;
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        //transform.position = eventData.position;
        transform.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
