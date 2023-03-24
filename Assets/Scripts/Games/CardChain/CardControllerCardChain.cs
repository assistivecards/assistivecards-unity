using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour, IPointerDownHandler, IDragHandler
{   
    public string rightCardName;
    public string leftCardName;

    public string rightCarConnectionPos;
    public string leftCardNameConnectionPos;

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void GetChildNames()
    {
        rightCardName = this.transform.GetChild(0).gameObject.name;
        leftCardName = this.transform.GetChild(1).gameObject.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 

    }
}
