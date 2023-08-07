using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DragInsideMatchDetection : MonoBehaviour
{
    public List<GameObject> cardsInside = new List<GameObject>();
    public List<GameObject> wrongCardsInside = new List<GameObject>();
    public List<GameObject> correctCardsInside = new List<GameObject>();
    Color green;
    Color red;
    Color original;
    private DragInsideBoardGenerator board;
    public int correctMatches;
    private DragInsideUIController UIController;
    [SerializeField] GameObject[] cardParents;
    private GameAPI gameAPI;
    private BoxCollider2D coll;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#1B9738", out green);
        ColorUtility.TryParseHtmlString("#972F1B", out red);
        ColorUtility.TryParseHtmlString("#3E455B", out original);
        board = GameObject.Find("GamePanel").GetComponent<DragInsideBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<DragInsideUIController>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (coll.bounds.Contains(other.bounds.max) && coll.bounds.Contains(other.bounds.min) && !other.GetComponent<DragInsideDraggableCard>().isAdded)
        {
            cardsInside.Add(other.gameObject);
            other.GetComponent<DragInsideDraggableCard>().isAdded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        cardsInside.Remove(other.gameObject);
        other.GetComponent<DragInsideDraggableCard>().isAdded = false;
    }

    public void CheckCardsInside()
    {
        for (int i = 0; i < cardsInside.Count; i++)
        {
            cardsInside[i].transform.SetParent(GameObject.Find("TargetAreaGhost").transform);
        }
        wrongCardsInside = cardsInside.Where(card => card.tag == "WrongCard").ToList();
        correctCardsInside = cardsInside.Where(card => card.tag == "CorrectCard").ToList();

        if (correctCardsInside.Count == 2 && wrongCardsInside.Count == 0)
        {
            Debug.Log("LEVEL COMPLETED");
            gameAPI.AddSessionExp();
            correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;

            for (int i = 0; i < cardParents.Length; i++)
            {
                cardParents[i].GetComponent<DragInsideDraggableCard>().enabled = false;
            }

            LeanTween.color(transform.GetChild(0).GetComponent<Image>().rectTransform, green, .2f);
            gameAPI.PlaySFX("Success");
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (correctMatches == 5)
            {
                board.Invoke("ScaleFrameDown", 1f);
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }

            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);

        }

        else if (cardsInside.Count >= 2 && wrongCardsInside.Count != 0)
        {
            Debug.Log("LEVEL NOT COMPLETED");
            gameAPI.RemoveSessionExp();
            LeanTween.color(transform.GetChild(0).GetComponent<Image>().rectTransform, red, .2f);
        }

        else
        {
            LeanTween.color(transform.GetChild(0).GetComponent<Image>().rectTransform, original, .2f);
        }

    }
}
