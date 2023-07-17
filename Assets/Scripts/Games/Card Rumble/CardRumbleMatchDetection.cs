using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardRumbleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    private CardRumbleBoardGenerator board;

    void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardRumbleBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardTitle)
        {
            Debug.Log("CORRECT MATCH!");
        }
        else
        {
            Debug.Log("WRONG MATCH!");
        }
    }
}
