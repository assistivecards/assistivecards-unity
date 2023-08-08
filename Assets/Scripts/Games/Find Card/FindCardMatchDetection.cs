using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCardMatchDetection : MonoBehaviour
{
    private GameAPI gameAPI;
    public List<GameObject> flippedCards = new List<GameObject>();
    private FindCardBoardGenerator board;
    private FindCardUIController UIController;

    private void Start()
    {
        board = gameObject.GetComponent<FindCardBoardGenerator>();
        UIController = gameObject.GetComponent<FindCardUIController>();
    }

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void CheckCard(Transform flippedCard)
    {
        if (flippedCard.tag == "CorrectCard")
        {
            Debug.Log("CORRECT CARD");
            gameAPI.AddSessionExp();
            flippedCards.Add(flippedCard.gameObject);
            gameAPI.PlaySFX("Success");
            Debug.Log(board.cardsNeeded);

            if (flippedCards.Count == board.cardsNeeded)
            {
                Debug.Log("LEVEL COMPLETED");
                UIController.levelsCompleted++;
                DisableFlip();
                PlayLevelCompletedAnimation();
                UIController.backButton.GetComponent<Button>().interactable = false;
                board.Invoke("ReadCard", 0.25f);
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

        else if (flippedCard.tag == "WrongCard")
        {
            Debug.Log("WRONG CARD");
            gameAPI.RemoveSessionExp();
            LeanTween.alpha(flippedCard.GetComponent<RectTransform>(), .5f, .25f);
            // LeanTween.rotateY(flippedCard.gameObject, 0, .75f);
            // gameAPI.PlaySFX("FlipCardBack");
        }

    }

    private void PlayLevelCompletedAnimation()
    {
        for (int i = 0; i < flippedCards.Count; i++)
        {
            LeanTween.scale(flippedCards[i], Vector3.one * 1.15f, .25f);
        }
    }

    public void DisableFlip()
    {
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            board.cardParents[i].GetComponent<FindCardFlipCard>().enabled = false;
        }
    }

}
