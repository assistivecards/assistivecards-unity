using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePuzzleAnchorPointDetection : MonoBehaviour
{
    public bool isMatched = false;
    public Transform matchedTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == gameObject.name)
        {
            isMatched = true;
            matchedTransform = other.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == gameObject.name)
        {
            isMatched = false;
        }
    }
}