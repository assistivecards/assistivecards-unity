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

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<DrawLinesBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<DrawLinesUIController>();
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
            gameAPI.PlaySFX("Success");
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.scale(matchedOption, Vector3.one * 1.25f, .25f);
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", .75f);
            board.Invoke("ClearBoard", 1f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                UIController.Invoke("OpenCheckPointPanel", 1f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1f);
        }
        else
        {
            isMatched = false;
            Debug.Log("Wrong Match!");
            gameObject.GetComponent<DragHandle>().enabled = false;
            LeanTween.scale(gameObject, Vector3.zero, .25f);
            Invoke("DisableCurrentHandle", 0.25f);
            LeanTween.alpha(matchedOption.GetComponent<RectTransform>(), .5f, .25f);
        }

    }

    public void DisableCurrentHandle()
    {
        gameObject.SetActive(false);
    }

}
