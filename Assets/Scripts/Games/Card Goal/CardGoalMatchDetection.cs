using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGoalMatchDetection : MonoBehaviour
{
    Color green;
    private CardGoalBoardGenerator board;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        board = GameObject.Find("GamePanel").GetComponent<CardGoalBoardGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.texture.name == board.correctCardSlug)
        {
            Debug.Log("Correct Match!");
        }

        else
        {
            Debug.Log("Wrong Match!");
        }
    }

}
