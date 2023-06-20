using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SizePuzzleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform[] cardParents;
    public float[] cardScales;
    private SizePuzzleBoardGenerator board;
    public bool isClicked = false;
    SizePuzzleProgressChecker progressChecker;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<SizePuzzleBoardGenerator>();
        progressChecker = GameObject.Find("GamePanel").GetComponent<SizePuzzleProgressChecker>();
    }
    public void OnPointerClick(PointerEventData eventData)
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

    private void GetCardScales()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardScales[i] = cardParents[i].transform.localScale.x;
        }
    }

    private void FadeCardParent()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), .5f, .25f);
    }

    private void ExecuteCorrectMatchProcedure()
    {
        for (int i = 0; i < cardParents.Length; i++)
        {
            cardParents[i].GetComponent<SizePuzzleMatchDetection>().isClicked = true;
        }

        progressChecker.correctMatches++;
        LeanTween.scale(gameObject, transform.localScale * 1.15f, .25f);
        board.Invoke("ScaleImagesDown", 1f);
        board.Invoke("ClearBoard", 1.30f);
        board.Invoke("GenerateRandomBoardAsync", 1.30f);
    }

}
