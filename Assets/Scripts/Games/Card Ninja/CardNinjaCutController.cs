using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardNinjaCutController : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject cutEffect;

    public void OnDrag(PointerEventData eventData)
    {
        cutEffect.transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
    }
}
