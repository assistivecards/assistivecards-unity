using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SizePuzzleMatchDetection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform[] cardParents;
    public float[] cardScales;
    private SizePuzzleBoardGenerator board;
    private bool isClicked = false;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<SizePuzzleBoardGenerator>();
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
                    Debug.Log("CORRECT CARD");
                }
                else
                {
                    Debug.Log("WRONG CARD");
                }
            }

            else if (board.selectedSize == "medium")
            {
                if (transform.localScale.x < Mathf.Max(cardScales) && transform.localScale.x > Mathf.Min(cardScales))
                {
                    Debug.Log("CORRECT CARD");
                }
                else
                {
                    Debug.Log("WRONG CARD");
                }
            }

            else if (board.selectedSize == "large")
            {
                if (transform.localScale.x == Mathf.Max(cardScales))
                {
                    Debug.Log("CORRECT CARD");
                }
                else
                {
                    Debug.Log("WRONG CARD");
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

}
