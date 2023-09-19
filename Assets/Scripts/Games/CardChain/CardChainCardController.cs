using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardChainCardController : MonoBehaviour
{
    GameAPI gameAPI;
    public GameObject leftCard;
    public GameObject rightCard;
    public string leftCardLocalName;
    public string rightCardLocalName;
    public Vector3 parentPos;

    private void OnEnable()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.GetComponent<CardChainCardController>() != null && GetComponent<CardChainDraggable>().touching)
        {
           if(other.GetComponent<CardChainCardController>().leftCardLocalName == rightCardLocalName)
           {
                other.transform.SetParent(this.transform);
                other.transform.position = rightCard.transform.position;
                other.GetComponent<CardChainDraggable>().enabled = false;
                rightCard = other.GetComponent<CardChainCardController>().rightCard;
                rightCardLocalName = other.GetComponent<CardChainCardController>().rightCardLocalName;
           }
            else if(other.GetComponent<CardChainCardController>().rightCardLocalName == leftCardLocalName)
           {
                other.transform.SetParent(this.transform);
                other.transform.position = leftCard.transform.position;
                other.GetComponent<CardChainDraggable>().enabled = false;
                leftCard = other.GetComponent<CardChainCardController>().leftCard;
                leftCardLocalName = other.GetComponent<CardChainCardController>().leftCardLocalName;
           }
        }
    }
}
