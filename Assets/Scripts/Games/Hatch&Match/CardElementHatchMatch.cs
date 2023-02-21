using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private EggController eggController;

    private void Start() 
    {
        eggController = FindObjectOfType<EggController>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
}
