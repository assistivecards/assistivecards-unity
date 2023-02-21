using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawLinesMatchDetection : MonoBehaviour
{
    public bool isMatched = false;
    [SerializeField] Image cardToBeMatched;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Option" && other.GetComponent<Image>().sprite == cardToBeMatched.sprite)
        {
            isMatched = true;
            Debug.Log("Correct Match!");
            gameObject.GetComponent<DragHandle>().enabled = false;
        }
        else
        {
            isMatched = false;
            Debug.Log("Wrong Match!");
            gameObject.GetComponent<DragHandle>().enabled = false;
        }

    }

}
