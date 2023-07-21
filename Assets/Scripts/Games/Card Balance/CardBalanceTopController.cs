using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBalanceTopController : MonoBehaviour
{
    [SerializeField] private GameObject TopCard;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            TopCard = other.gameObject;
            Debug.Log(other.gameObject.name);
        }
    }
}
