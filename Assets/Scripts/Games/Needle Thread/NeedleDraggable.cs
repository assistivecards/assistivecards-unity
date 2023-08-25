using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleDraggable : MonoBehaviour
{
    [SerializeField] NeedleMovement needleMovement;
    [SerializeField] private NeedleThreadBoardGenerator boardGenerator;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<NeedleCardName>().cardName == boardGenerator.targetCard && needleMovement.dragging)
        {
            LeanTween.scale(other.gameObject, Vector3.one, 0.4f);
            other.GetComponent<NeedleCardName>().cardName = null;
            boardGenerator.match++;
        }
    }
}
