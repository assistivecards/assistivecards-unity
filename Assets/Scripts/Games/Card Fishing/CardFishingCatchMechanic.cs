using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFishingCatchMechanic : MonoBehaviour
{
    [SerializeField] private CardFishingRodController cardFishingRodController;
    private bool catctedCard;
    private GameObject card;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(!catctedCard)
        {
            if(other.gameObject.tag == "card")
            {
                card = other.gameObject;
                catctedCard = true;
            }
        }
    }

    void Update()
    {
        if(card != null)
            MoveCard(card);
    }

    private void MoveCard(GameObject _card)
    {
        _card.transform.position = this.transform.GetChild(0).transform.position;
    }

}
