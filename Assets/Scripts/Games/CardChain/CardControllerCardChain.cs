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
        this.transform.parent.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.parent.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 

        if(this.GetComponentInParent<ChainController>().cardTypes.Contains(other.gameObject.name))
        {
            this.transform.parent.rotation = Quaternion.Euler(0, 0,0);
            foreach (var card in other.gameObject.GetComponentInParent<ChainController>().cards)
            {
                card.transform.SetParent(this.transform.parent);
            }
            //other.gameObject.GetComponentInParent<ChainController>().cards.Remove(other.gameObject);
            //Destroy(other.gameObject);
        }
        // if(other.gameObject.GetComponent<CardControllerCardChain>().firstCardLocalName == secondCardLocalName)
        // {
        //     this.transform.parent.rotation = Quaternion.Euler(0, 0,0);
        // }
        // else if(other.gameObject.GetComponent<CardControllerCardChain>().firstCardLocalName == firstCardLocalName)
        // {
        //     this.transform.parent.rotation = Quaternion.Euler(0, 0,0);
        // }
        // else if(other.gameObject.GetComponent<CardControllerCardChain>().secondCardLocalName == secondCardLocalName)
        // {
        //     this.transform.parent.rotation = Quaternion.Euler(0, 0,0);
        // }
    }
}
