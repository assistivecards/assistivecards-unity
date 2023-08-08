using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackCardsMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private GameAPI gameAPI;
    public bool isMatched = false;
    private Transform matchedSlotTransform;
    public int numOfMatchedCards;
    private StackCardsBoardGenerator board;
    private StackCardsUIController UIController;
    private StackCardsLevelProgressChecker progressChecker;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<StackCardsBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<StackCardsUIController>();
        progressChecker = GameObject.Find("GamePanel").GetComponent<StackCardsLevelProgressChecker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1 && other.tag == "FixedCard")
        {
            matchedSlotTransform = other.transform;
            isMatched = true;
            Debug.Log("Correct Match! ENTER");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1 && other.tag == "FixedCard")
        {
            isMatched = false;
            Debug.Log("Correct Match! EXIT");
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            gameAPI.AddSessionExp();
            gameObject.GetComponent<StackCardsDraggableCards>().enabled = false;
            transform.SetParent(matchedSlotTransform);
            LeanTween.moveLocal(gameObject, new Vector3(-20, -20, 0), 0.25f);
            LeanTween.rotate(gameObject, Vector3.zero, .25f);
            gameObject.tag = "FixedCard";
            ReadCard();

            if (CheckIfLevelComplete())
            {
                progressChecker.levelsCompleted++;
                gameAPI.PlaySFX("Success");
                UIController.backButton.GetComponent<Button>().interactable = false;
                Invoke("PlayLevelCompletedAnimation", .25f);
                board.Invoke("ScaleImagesDown", 1f);
                board.Invoke("ClearBoard", 1.3f);

                if (progressChecker.levelsCompleted == 3)
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
            transform.SetParent(GameObject.Find(gameObject.GetComponent<StackCardsDraggableCards>().parentName).transform);
            LeanTween.move(gameObject, transform.parent.position, .5f);
        }
    }

    private bool CheckIfLevelComplete()
    {
        var cards = GameObject.Find("Cards");

        for (int i = 0; i < cards.transform.childCount; i++)
        {
            if (cards.transform.GetChild(i).childCount == 0)
            {
                numOfMatchedCards++;
            }
        }

        if (numOfMatchedCards == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayLevelCompletedAnimation()
    {
        for (int i = 0; i < board.stackParents.Length; i++)
        {
            LeanTween.scale(board.stackParents[i], Vector3.one * 1.1f, .25f);
        }

    }

    public void ReadCard()
    {
        gameAPI.Speak(transform.GetChild(0).GetComponent<Image>().sprite.name);
    }
}
