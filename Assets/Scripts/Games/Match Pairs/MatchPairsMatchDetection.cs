using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchPairsMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private GameAPI gameAPI;
    public bool isMatched = false;
    private Transform matchedTransform;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            string otherName = other.transform.GetChild(1).name;
            string draggedName = transform.GetChild(1).name;

            if (otherName.Substring(0, otherName.Length - 1) == draggedName.Substring(0, draggedName.Length - 1))
            {
                matchedTransform = other.transform;
                isMatched = true;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            string otherName = other.transform.GetChild(1).name;
            string draggedName = transform.GetChild(1).name;

            if (otherName.Substring(0, otherName.Length - 1) == draggedName.Substring(0, draggedName.Length - 1))
            {
                isMatched = false;
            }

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            Debug.Log("Correct Match!");
        }
        else
            Debug.Log("Wrong Match!");
    }
}
