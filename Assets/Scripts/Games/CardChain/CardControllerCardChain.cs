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

        if(this.gameObject.name == other.gameObject.name)
        {
            StartCoroutine(MoveOtherCard(other));
        }

        IEnumerator MoveOtherCard(Collider2D _other)
        {
            var othersParent = _other.transform.parent;
            foreach (var card in othersParent.GetComponent<ChainController>().cards)
            {
                if(card.gameObject == _other.gameObject)
                    othersParent.transform.SetParent(this.transform);
            }
            //_other.gameObject.SetActive(false);
            //othersParent.SetParent(this.transform.parent);
            GetComponentInParent<ChainController>().GetChildList();

            yield return new WaitForSeconds(5);
        }


    }
}
