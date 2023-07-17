using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardRumbleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    private CardRumbleBoardGenerator board;
    public bool isClicked = false;

    void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardRumbleBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardTitle && !isClicked)
        {
            Debug.Log("CORRECT MATCH!");
            isClicked = true;
            LeanTween.pause(gameObject);
            LeanTween.rotateZ(gameObject, 0, .25f);
            LeanTween.scale(gameObject, Vector3.one * 1.25f, .25f).setOnComplete(ScaleCardDown);
            board.numOfMatchedCards++;

            if (CheckIfLevelComplete())
            {
                Debug.Log("LEVEL COMPLETE!");
                Invoke("PlayLevelCompletedAnimation", .55f);
                board.Invoke("ScaleImagesDown", 1f);
                board.Invoke("ClearBoard", 1.3f);
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
            }

        }

        else if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name != board.correctCardTitle)
        {
            Debug.Log("WRONG MATCH!");
            LeanTween.scale(gameObject, Vector3.one * .85f, .15f).setOnComplete(ScaleBackToNormal);
        }
    }

    private void ScaleBackToNormal()
    {
        LeanTween.scale(gameObject, Vector3.one, .15f);
    }

    private void ScaleCardDown()
    {
        LeanTween.scale(gameObject, Vector3.zero, .25f);

    }

    private bool CheckIfLevelComplete()
    {

        if (board.numOfMatchedCards == board.numOfCorrectCards)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void PlayLevelCompletedAnimation()
    {
        LeanTween.pauseAll();
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            if (!board.cardParents[i].GetComponent<CardRumbleMatchDetection>().isClicked)
            {
                LeanTween.rotateZ(board.cardParents[i], 0, .25f);
                // LeanTween.scale(board.cardParents[i], Vector3.one * 1.25f, .25f);
            }

        }
    }

}
