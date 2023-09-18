using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardChainCardController : MonoBehaviour, IDragHandler
{
    GameAPI gameAPI;
    public string leftCardLocalName;
    public string rightCardLocalName;
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
}
