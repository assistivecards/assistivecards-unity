using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardControllerCardChain : MonoBehaviour, IPointerDownHandler, IDragHandler
{   
    public string firstCardLocalName;
    public string secondCardLocalName;

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.GetComponent<CardControllerCardChain>().firstCardLocalName == secondCardLocalName)
        {
            Debug.Log("second + first  Type:" + secondCardLocalName);
        }
        else if(other.gameObject.GetComponent<CardControllerCardChain>().firstCardLocalName == firstCardLocalName)
        {
            Debug.Log("first + first  Type:" + firstCardLocalName);
        }
        else if(other.gameObject.GetComponent<CardControllerCardChain>().secondCardLocalName == secondCardLocalName)
        {
            Debug.Log("second + second   Type:" + secondCardLocalName);
        }
    }
}
