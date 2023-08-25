using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleDraggable : MonoBehaviour
{
    [SerializeField] private NeedleThreadBoardGenerator boardGenerator;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("!!!!!!!!!!!!");
        if(other.GetComponent<NeedleCardName>().cardName == boardGenerator.targetCard)
        {
            Debug.Log("MATCH");
        }
    }
}
