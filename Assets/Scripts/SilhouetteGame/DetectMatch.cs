using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DetectMatch : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Transform shownImageSlot;
    private bool isMatched = false;
    [SerializeField] Board board;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            isMatched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            isMatched = false;
        }
    }

    public async void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            //correct match
            transform.position = shownImageSlot.position;
            Debug.Log("Matched!");
            board.ClearBoard();
            await board.GenerateRandomBoardAsync();
        }

        else
        {
            //wrong match
            transform.position = shownImageSlot.position;
        }

    }
}
