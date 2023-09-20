using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SizePuzzleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform[] cardParents;
    public float[] cardScales;
    private SizePuzzleBoardGenerator board;
    public bool isClicked = false;
    private SizePuzzleUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<SizePuzzleBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<SizePuzzleUIController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            if (!isClicked)
            {
                GetCardScales();

                if (board.selectedSize == "small")
                {
                    if (transform.localScale.x == Mathf.Min(cardScales))
                    {
                        ExecuteCorrectMatchProcedure();
                    }
                    else
                    {
                        FadeCardParent();
                    }
                }

                else if (board.selectedSize == "medium")
                {
                    if (transform.localScale.x < Mathf.Max(cardScales) && transform.localScale.x > Mathf.Min(cardScales))
                    {
                        ExecuteCorrectMatchProcedure();
                    }
                    else
                    {
                        FadeCardParent();
                    }
                }

                else if (board.selectedSize == "large")
                {
                    if (transform.localScale.x == Mathf.Max(cardScales))
                    {
                        ExecuteCorrectMatchProcedure();
                    }
                    else
                    {
                        FadeCardParent();
                    }
                }

                isClicked = true;
            }
        }


    }

    private void GetCardScales()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardScales[i] = cardParents[i].transform.localScale.x;
        }
    }

    private void FadeCardParent()
    {
        gameAPI.RemoveSessionExp();
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), .5f, .25f);
    }

    private void ExecuteCorrectMatchProcedure()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<SizePuzzleMatchDetection>().isClicked = true;
        }

        UIController.correctMatches++;
        gameAPI.AddSessionExp();
        UIController.backButton.GetComponent<Button>().interactable = false;
        gameAPI.PlaySFX("Success");
        board.Invoke("ReadCard", 0.25f);
        LeanTween.scale(gameObject, transform.localScale * 1.15f, .25f);
        board.Invoke("ScaleImagesDown", 1f);
        board.Invoke("ClearBoard", 1.30f);

        if (UIController.correctMatches == UIController.checkpointFrequency)
        {
            gameAPI.AddExp(gameAPI.sessionExp);
            UIController.Invoke("OpenCheckPointPanel", 1.3f);
        }
        else
            board.Invoke("GenerateRandomBoardAsync", 1.3f);
    }

}
