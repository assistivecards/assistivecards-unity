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
    private SplitPuzzleUIController UIController;


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
        UIController = GameObject.Find("GamePanel").GetComponent<SplitPuzzleUIController>();

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
            gameAPI.AddSessionExp();
            gameObject.GetComponent<DraggablePiece>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            LeanTween.move(gameObject, matchedSlotTransform.position, 0.25f);
            transform.SetParent(hintImageParent.transform);
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(matchedSlotTransform.position);
            if (puzzleProgressChecker.correctMatches == 4)
            {
                Debug.Log("Puzzle completed!");
                puzzleProgressChecker.puzzlesCompleted++;
                puzzleProgressChecker.correctMatches = 0;
                puzzleProgressChecker.backButton.GetComponent<Button>().interactable = false;
                // for (int i = 0; i < puzzlePieceParents.Count; i++)
                // {
                //      puzzlePieceParents[i].transform.SetParent(hintImageParent.transform);
                //      puzzlePieceParents[i].GetComponent<SplitPuzzleMatchDetection>().isMatched = false;
                // }
                LeanTween.alpha(lightSlotsParent.GetComponent<RectTransform>(), 0, .15f);
                LeanTween.alpha(darkSlotsParent.GetComponent<RectTransform>(), 0, .25f);
                puzzleBoard.Invoke("ReadCard", 0.25f);
                Invoke("ScaleHintImageUp", 0.25f);

                Invoke("ScaleHintImageDown", 1f);
                puzzleBoard.Invoke("ClearBoard", 1.3f);

                if (puzzleProgressChecker.puzzlesCompleted == 5)
                {
                    gameAPI.AddExp(gameAPI.sessionExp);
                    UIController.Invoke("OpenCheckPointPanel", 1.3f);
                }
                else
                    puzzleBoard.Invoke("GenerateRandomBoardAsync", 1.3f);

            }
        }
        else
        {
            // transform.SetParent(GameObject.Find(gameObject.GetComponent<DraggablePiece>().parentName).transform);
            // LeanTween.move(gameObject, transform.parent.position, .5f);
            gameAPI.RemoveSessionExp();
        }
    }

    public void ScaleHintImageUp()
    {
        LeanTween.scale(hintImageParent, Vector3.one * 1.25f, .25f);
    }

    public void ScaleHintImageDown()
    {
        LeanTween.scale(hintImageParent, Vector3.zero, .25f);
        LeanTween.scale(darkSlotsParent, Vector3.zero, .1f);
        LeanTween.scale(lightSlotsParent, Vector3.zero, .1f);
    }

}
