using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawLinesMatchDetection : MonoBehaviour
{
    public bool isMatched = false;
    [SerializeField] Image cardToBeMatched;
    private GameObject matchedOption;
    private DrawLinesBoardGenerator board;
    private DrawLinesUIController UIController;
    private GameAPI gameAPI;
    private DragHandle dragHandle;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<DrawLinesBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<DrawLinesUIController>();
        dragHandle = gameObject.GetComponent<DragHandle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        matchedOption = other.gameObject;
        if (other.tag == "Option" && other.GetComponent<Image>().sprite == cardToBeMatched.sprite)
        {
            isMatched = true;
            UIController.correctMatches++;
            UIController.backButton.GetComponent<Button>().interactable = false;
            Debug.Log("Correct Match!");
            gameAPI.AddSessionExp();
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(matchedOption.transform.position);
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            for (int i = 0; i < dragHandle.waypoints.Count; i++)
            {
                LeanTween.color(dragHandle.waypoints[i].GetComponent<RectTransform>(), dragHandle.waypointGreen, .25f);
            }
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.scale(matchedOption, Vector3.one * 1.25f, .25f);
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", .75f);
            board.Invoke("ClearBoard", 1.05f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.05f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.05f);
        }
        else
        {
            isMatched = false;
            Debug.Log("Wrong Match!");
            gameAPI.RemoveSessionExp();
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            for (int i = 0; i < dragHandle.waypoints.Count; i++)
            {
                LeanTween.color(dragHandle.waypoints[i].GetComponent<RectTransform>(), dragHandle.waypointGrey, .25f);
            }
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.alpha(matchedOption.GetComponent<RectTransform>(), .5f, .25f);
        }

    }

    public void DisableCurrentHandle()
    {
        gameObject.SetActive(false);
    }

}
