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
            other.GetComponent<NeedleCardName>().matched = true;
            other.GetComponent<NeedleCardName>().Invoke("ScaleDownCrad", 0.4f);
            boardGenerator.Invoke("CheckTargetCards", 0.5f);
        }
    }

    public void MoveToCenter()
    {
        LeanTween.move(this.gameObject, Vector3.zero, 0.1f);
    }
}
