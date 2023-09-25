using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PiecePuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    public bool correctMatch = false;
    private PuzzleProgressChecker puzzleProgressChecker;
    private PiecePuzzleBoardGenerator board;
    [SerializeField] GameObject hintImage;
    private PiecePuzzleUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
        board = GameObject.Find("GamePanel").GetComponent<PiecePuzzleBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<PiecePuzzleUIController>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (correctMatch)
        {
            Debug.Log("Correct Match!");
            gameAPI.AddSessionExp();
            puzzleProgressChecker.correctMatches++;
            gameObject.GetComponent<PiecePuzzleDraggablePiece>().enabled = false;
            LeanTween.move(gameObject, transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent.transform.position, .25f);
            transform.SetParent(transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent);
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(transform.GetChild(0).GetComponent<PiecePuzzleAnchorPointDetection>().matchedTransform.parent.position);
            LeanTween.alpha(transform.GetChild(2).GetComponent<RectTransform>(), 0, .25f);

            if (puzzleProgressChecker.correctMatches == 4)
            {
                Debug.Log("Puzzle completed!");
                puzzleProgressChecker.puzzlesCompleted++;
                puzzleProgressChecker.correctMatches = 0;
                puzzleProgressChecker.backButton.GetComponent<Button>().interactable = false;
                board.Invoke("ReadCard", 0.25f);
                Invoke("ScaleHintImageUp", 0.25f);
                Invoke("ScaleHintImageDown", 1f);
                board.Invoke("ClearBoard", 1.3f);

                if (puzzleProgressChecker.puzzlesCompleted == 5)
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
            Debug.Log("Wrong Match!");
            gameAPI.RemoveSessionExp();
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
