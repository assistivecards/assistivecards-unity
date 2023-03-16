using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PiecePuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    public bool correctMatch = false;
    private PuzzleProgressChecker puzzleProgressChecker;
    private PiecePuzzleBoardGenerator board;
    [SerializeField] GameObject hintImage;

    private void Start()
    {
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
        board = GameObject.Find("GamePanel").GetComponent<PiecePuzzleBoardGenerator>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (correctMatch)
        {
            Debug.Log("Correct Match!");
            puzzleProgressChecker.correctMatches++;
            gameObject.GetComponent<PiecePuzzleDraggablePiece>().enabled = false;
            LeanTween.move(gameObject, transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent.transform.position, .25f);
            transform.SetParent(transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent);

            if (puzzleProgressChecker.correctMatches == 4)
            {
                Debug.Log("Puzzle completed!");
                puzzleProgressChecker.puzzlesCompleted++;
                puzzleProgressChecker.correctMatches = 0;
                Invoke("ScaleHintImageUp", 0.25f);
                Invoke("ScaleHintImageDown", 1f);
                board.Invoke("ClearBoard", 1.3f);
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
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

    public void ScaleHintImageUp()
    {
        LeanTween.scale(hintImage, Vector3.one * 1.25f, .25f);
    }

    public void ScaleHintImageDown()
    {
        LeanTween.scale(hintImage, Vector3.zero, .25f);
    }
}
