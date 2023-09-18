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
    private CardRumbleUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<CardRumbleBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<CardRumbleUIController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardTitle && !isClicked)
            {
                Debug.Log("CORRECT MATCH!");
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                isClicked = true;
                LeanTween.pause(gameObject);
                LeanTween.rotateZ(gameObject, 0, .25f);
                LeanTween.scale(gameObject, Vector3.one * 1.25f, .25f).setOnComplete(ScaleCardDown);
                ReadCard();
                board.numOfMatchedCards++;

                if (CheckIfLevelComplete())
                {
                    Debug.Log("LEVEL COMPLETE!");
                    UIController.levelsCompleted++;
                    DisableMatchDetection();
                    UIController.backButton.GetComponent<Button>().interactable = false;
                    Invoke("PlayLevelCompletedAnimation", .55f);
                    board.Invoke("ScaleImagesDown", 1f);
                    board.Invoke("ClearBoard", 1.3f);

                    if (UIController.levelsCompleted == UIController.checkpointFrequency)
                    {
                        gameAPI.AddExp(gameAPI.sessionExp);
                        UIController.Invoke("OpenCheckPointPanel", 1.3f);
                    }
                    else
                        board.Invoke("GenerateRandomBoardAsync", 1.3f);
                }

            }

            else if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name != board.correctCardTitle)
            {
                Debug.Log("WRONG MATCH!");
                gameAPI.RemoveSessionExp();
                gameAPI.PlaySFX("Pickup");
                LeanTween.scale(gameObject, Vector3.one * .85f, .15f).setOnComplete(ScaleBackToNormal);
            }
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

    private void DisableMatchDetection()
    {
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            board.cardParents[i].GetComponent<CardRumbleMatchDetection>().enabled = false;
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(transform.GetChild(0).GetComponent<Image>().sprite.texture.name);
    }

}
