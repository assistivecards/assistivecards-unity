using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingCatchMechanic : MonoBehaviour
{
    [SerializeField] private CardFishingRodController cardFishingRodController;
    private bool catctedCard;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(!catctedCard)
        {
            if(other.gameObject.tag == "card")
            {
                Debug.Log(other.gameObject.name);
                catctedCard = true;
                other.transform.position = this.transform.GetChild(0).transform.position;
            }
        }
    }
}
