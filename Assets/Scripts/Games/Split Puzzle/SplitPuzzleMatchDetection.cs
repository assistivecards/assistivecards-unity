using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SplitPuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private PuzzleProgressChecker puzzleProgressChecker;
    private GameAPI gameAPI;
    private bool isMatched = false;
    private Transform matchedSlotTransform;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HintPiece" && other.GetComponent<Image>().sprite == transform.GetChild(1).GetComponent<Image>().sprite)
        {
            matchedSlotTransform = other.transform;
            isMatched = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "HintPiece" && other.GetComponent<Image>().sprite == transform.GetChild(1).GetComponent<Image>().sprite)
        {
            isMatched = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            puzzleProgressChecker.correctMatches++;
            gameObject.GetComponent<DraggablePiece>().enabled = false;
            LeanTween.move(gameObject, matchedSlotTransform.position, 0.25f);
            gameAPI.PlaySFX("Success");
            if (puzzleProgressChecker.correctMatches == 4)
            {
                Debug.Log("Puzzle completed!");
                puzzleProgressChecker.puzzlesCompleted++;
            }
        }
        else
            Debug.Log("Wrong Match!");
    }

}
