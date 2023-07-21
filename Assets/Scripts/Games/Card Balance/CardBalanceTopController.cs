using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBalanceTopController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
