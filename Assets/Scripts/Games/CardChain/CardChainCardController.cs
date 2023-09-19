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
    public GameObject otherGameObject;

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
                if(other.transform.parent.tag == "Card")
                {
                    otherGameObject = other.transform.parent.gameObject;
                }
                else
                {
                    otherGameObject = other.gameObject;
                }
                otherGameObject.transform.SetParent(this.transform);
                otherGameObject.transform.tag = "Untagged";
                otherGameObject.transform.position = rightCard.transform.position;
                rightCard = otherGameObject.GetComponent<CardChainCardController>().rightCard;
                //LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.5f).setOnComplete(ScaleDown);
                rightCardLocalName = otherGameObject.GetComponent<CardChainCardController>().rightCardLocalName;
                otherGameObject.GetComponent<CardChainDraggable>().enabled = false;
           }
            else if(other.GetComponent<CardChainCardController>().rightCardLocalName == leftCardLocalName)
           {
                if(other.transform.parent.tag == "Card")
                {
                    otherGameObject = other.transform.parent.gameObject;
                }
                else
                {
                    otherGameObject = other.gameObject;
                }
                otherGameObject.transform.SetParent(this.transform);
                otherGameObject.transform.tag = "Untagged";
                otherGameObject.transform.position = leftCard.transform.position;
                leftCard = otherGameObject.GetComponent<CardChainCardController>().leftCard;
                //LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.5f).setOnComplete(ScaleDown);
                leftCardLocalName = otherGameObject.GetComponent<CardChainCardController>().leftCardLocalName;
                otherGameObject.GetComponent<CardChainDraggable>().enabled = false;
           }
        }
    }

    private void ScaleDown()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.25f);
    }
}
