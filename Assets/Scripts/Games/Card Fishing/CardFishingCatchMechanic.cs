using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingCatchMechanic : MonoBehaviour
{
    [SerializeField] private CardFishingRodController cardFishingRodController;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(!cardFishingRodController.isPointerDown)
        {
            if(other.gameObject.tag == "card")
            {
                Debug.Log(other.gameObject.name);
            }
        }
    }
}
