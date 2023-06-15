using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardNinjaCutController : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject cutEffect;
    private Vector2 touchPosition;

    public void OnDrag(PointerEventData eventData)
    {
        touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        cutEffect.transform.position = trailPos;
    }
}
