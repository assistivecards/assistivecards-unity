using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlingMatchDetection : MonoBehaviour
{
    Color green;
    private SlingBoardGenerator board;
    public int correctMatches = 0;
    private SlingUIController UIController;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        board = GameObject.Find("GamePanel").GetComponent<SlingBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<SlingUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Successful Shot!");

        for (int i = 0; i < transform.parent.childCount - 1; i++)
        {
            LeanTween.color(transform.parent.GetChild(i).gameObject, green, .2f);
        }

        correctMatches++;
        UIController.backButton.GetComponent<Button>().interactable = false;
        board.Invoke("ScaleImagesDown", 1f);
        board.Invoke("ClearBoard", 1.3f);

        if (correctMatches == 5)
        {
            board.Invoke("ScaleBoxDown", 1f);
            UIController.Invoke("OpenCheckPointPanel", 1.3f);
        }
        else
            board.Invoke("GenerateRandomBoardAsync", 1.3f);
    }

}
