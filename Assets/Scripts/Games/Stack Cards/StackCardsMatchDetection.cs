using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackCardsMatchDetection : MonoBehaviour
{
    private GameAPI gameAPI;
    public bool isMatched = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1)
        {
            isMatched = true;
            Debug.Log("Correct Match! ENTER");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1)
        {
            isMatched = false;
            Debug.Log("Correct Match! EXIT");
        }

    }

}
