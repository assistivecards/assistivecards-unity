using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PiecePuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    public bool correctMatch = false;
    private PuzzleProgressChecker puzzleProgressChecker;

    private void Start()
    {
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (correctMatch)
        {
            Debug.Log("Correct Match!");
            puzzleProgressChecker.correctMatches++;
            LeanTween.move(gameObject, transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent.transform.position, .25f);
            transform.SetParent(transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent);

            if (puzzleProgressChecker.correctMatches == 4)
            {
                Debug.Log("Puzzle completed!");
                puzzleProgressChecker.puzzlesCompleted++;
                puzzleProgressChecker.correctMatches = 0;
            }
        }
        else
        {
            Debug.Log("Wrong Match!");
        }

    }

    private void Update()
    {

        if (transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().isMatched == true)
        {
            correctMatch = true;
        }
        else
        {
            correctMatch = false;
        }

    }
}
