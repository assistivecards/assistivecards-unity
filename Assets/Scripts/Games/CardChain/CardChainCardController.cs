using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardChainCardController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    GameAPI gameAPI;
    public GameObject leftCard;
    public GameObject rightCard;
    public string leftCardLocalName;
    public string rightCardLocalName;
    public bool touching;
    public bool cantMove;

    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!cantMove)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touching = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.GetComponent<CardChainCardController>() != null && touching)
        {
           if(other.GetComponent<CardChainCardController>().leftCardLocalName == rightCardLocalName)
           {
                LeanTween.move(other.gameObject, rightCard.transform.position, 0.2f);
                other.transform.SetParent(this.transform);
                other.GetComponent<CardChainCardController>().cantMove = true;

           }
            else if(other.GetComponent<CardChainCardController>().rightCardLocalName == leftCardLocalName)
           {
                LeanTween.move(other.gameObject, leftCard.transform.position, 0.2f);
                other.transform.SetParent(this.transform);
                other.GetComponent<CardChainCardController>().cantMove = true;
           }
        }
    }
}
