using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SplitPuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private bool isMatched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HintPiece" && other.GetComponent<Image>().sprite == transform.GetChild(1).GetComponent<Image>().sprite)
        {
            isMatched = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "HintPiece" && other.GetComponent<Image>().sprite == transform.GetChild(1).GetComponent<Image>().sprite)
        {
            isMatched = false;
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
