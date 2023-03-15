using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PiecePuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    public bool correctMatch = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (correctMatch)
        {
            Debug.Log("Correct Match!");
            LeanTween.move(gameObject, transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent.transform.position, .25f);
            transform.SetParent(transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent);
        }
        else
        {
            Debug.Log("Wrong Match!");
        }

    }

    private void Update()
    {

        if (transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().isMatched == true)
        {
            correctMatch = true;
        }
        else
        {
            correctMatch = false;
        }

    }
}
