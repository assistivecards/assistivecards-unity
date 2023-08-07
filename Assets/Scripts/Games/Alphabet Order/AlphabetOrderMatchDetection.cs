using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlphabetOrderMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private Transform matchedSlotTransform;
    public bool isMatched = false;
    public int numOfMatchedCards;
    private AlphabetOrderBoardGenerator board;
    private AlphabetOrderUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<AlphabetOrderBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<AlphabetOrderUIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
        {
            matchedSlotTransform = other.transform;
            isMatched = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == transform.GetChild(0).GetComponent<Image>().sprite.texture.name)
        {
            isMatched = false;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            gameAPI.PlaySFX("Success");
            gameAPI.AddSessionExp();
            gameObject.GetComponent<AlphabetOrderDraggableCard>().enabled = false;
            transform.SetParent(matchedSlotTransform);
            LeanTween.move(gameObject, matchedSlotTransform, 0.25f);
            LeanTween.rotate(gameObject, Vector3.zero, .25f);
            ReadCard();

            if (CheckIfLevelComplete())
            {
                Debug.Log("LEVEL COMPLETED");
                UIController.levelsCompleted++;
                UIController.backButton.GetComponent<Button>().interactable = false;
                Invoke("PlayLevelCompletedAnimation", .25f);
                board.Invoke("ScaleImagesDown", 1f);
                board.Invoke("ClearBoard", 1.3f);

                if (UIController.levelsCompleted == 5)
                {
                    gameAPI.AddExp(gameAPI.sessionExp);
                    UIController.Invoke("OpenCheckPointPanel", 1.3f);
                }
                else
                    board.Invoke("GenerateRandomBoardAsync", 1.3f);

            }
        }

        else
        {
            gameAPI.RemoveSessionExp();
            transform.SetParent(GameObject.Find(gameObject.GetComponent<AlphabetOrderDraggableCard>().parentName).transform);
            LeanTween.move(gameObject, transform.parent.position, .5f);
        }
    }

    private bool CheckIfLevelComplete()
    {
        var cardSlots = GameObject.Find("CardSlots");

        for (int i = 0; i < cardSlots.transform.childCount; i++)
        {
            if (cardSlots.transform.GetChild(i).childCount == 0)
            {
                numOfMatchedCards++;
            }
        }

        if (numOfMatchedCards == cardSlots.transform.childCount)
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
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            LeanTween.scale(board.cardParents[i], Vector3.one * 1.1f, .25f);
        }
    }

    public void ReadCard()
    {
        gameAPI.Speak(transform.GetChild(0).GetComponent<Image>().sprite.texture.name);
    }

}
