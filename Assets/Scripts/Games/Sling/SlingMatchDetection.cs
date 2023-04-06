using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingMatchDetection : MonoBehaviour
{
    Color green;
    private SlingBoardGenerator board;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        board = GameObject.Find("GamePanel").GetComponent<SlingBoardGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Successful Shot!");
        for (int i = 0; i < transform.parent.childCount - 1; i++)
        {
            LeanTween.color(transform.parent.GetChild(i).gameObject, green, .2f);
        }
        board.Invoke("ScaleImagesDown", 1f);
        board.Invoke("ClearBoard", 1.30f);
        board.Invoke("GenerateRandomBoardAsync", 1.30f);
    }

}
