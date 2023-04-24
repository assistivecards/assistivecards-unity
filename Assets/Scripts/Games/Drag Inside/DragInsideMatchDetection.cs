using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragInsideMatchDetection : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] BoxCollider2D targetArea;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (GetComponent<Collider2D>() == Physics2D.OverlapBox(targetArea.bounds.center, targetArea.size, 0))
        {
            if (gameObject.tag == "CorrectCard")
            {
                Debug.Log("CORRECT CARD INSIDE");
            }

            else if (gameObject.tag == "WrongCard")
            {
                Debug.Log("WRONG CARD INSIDE");
            }
        }

        else
        {
            Debug.Log("NOT INSIDE");
        }
    }
}
