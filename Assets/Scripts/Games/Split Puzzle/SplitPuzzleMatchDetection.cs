using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SplitPuzzleMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private PuzzleProgressChecker puzzleProgressChecker;
    private SplitPuzzleBoardGenerator puzzleBoard;
    private GameAPI gameAPI;
    public bool isMatched = false;
    private Transform matchedSlotTransform;
    private GameObject darkSlotsParent;
    private GameObject lightSlotsParent;
    [SerializeField] List<GameObject> puzzlePieceParents = new List<GameObject>();
    [SerializeField] GameObject hintImageParent;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        puzzleProgressChecker = GameObject.Find("GamePanel").GetComponent<PuzzleProgressChecker>();
        puzzleBoard = GameObject.Find("GamePanel").GetComponent<SplitPuzzleBoardGenerator>();
        darkSlotsParent = GameObject.Find("PuzzleSlotsDark");
        lightSlotsParent = GameObject.Find("PuzzleSlotsLight");

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
                puzzleProgressChecker.correctMatches = 0;
                for (int i = 0; i < puzzlePieceParents.Count; i++)
                {
                    puzzlePieceParents[i].transform.SetParent(hintImageParent.transform);
                    puzzlePieceParents[i].GetComponent<SplitPuzzleMatchDetection>().isMatched = false;
                }
                LeanTween.alpha(lightSlotsParent.GetComponent<RectTransform>(), 0, .5f);
                LeanTween.alpha(darkSlotsParent.GetComponent<RectTransform>(), 0, .25f);

                Invoke("ScaleHintImageDown", .5f);
                puzzleBoard.Invoke("ClearBoard", 1f);
                puzzleBoard.Invoke("GenerateRandomBoardAsync", 1f);


            }
        }
        else
            Debug.Log("Wrong Match!");
    }

    public void ScaleHintImageDown()
    {
        LeanTween.scale(hintImageParent, Vector3.zero, .25f);
        LeanTween.scale(darkSlotsParent, Vector3.zero, .1f);
        LeanTween.scale(lightSlotsParent, Vector3.zero, .1f);
    }

}