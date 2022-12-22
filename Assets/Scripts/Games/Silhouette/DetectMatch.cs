using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DetectMatch : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] Transform shownImageSlot;
    private bool isMatched = false;
    [SerializeField] Board board;
    private GameAPI gameAPI;
    private Transform matchedImageTransform;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject[] silhouettes;
    [SerializeField] GameObject cardName;
    public static int correctMatches;
    [SerializeField] GameObject checkPointPanel;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject backButton;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            matchedImageTransform = other.transform;
            isMatched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.GetComponent<Image>().sprite == other.gameObject.GetComponent<Image>().sprite)
        {
            isMatched = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var bounds = gamePanel.GetComponent<BoxCollider2D>().bounds;
        if (isMatched)
        {
            //correct match
            correctMatches++;
            transform.position = matchedImageTransform.position;
            gameAPI.VibrateStrong();
            gameAPI.PlaySFX("Success");
            LeanTween.color(matchedImageTransform.gameObject.GetComponent<Image>().rectTransform, Color.white, .5f);
            Invoke("ScaleImagesDown", .5f);
            board.Invoke("ClearBoard", 1f);
            isMatched = false;
            if (correctMatches == 10)
            {
                OpenCheckPointPanel();
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1f);
        }

        else
        {
            //wrong match
            if (eventData.position.x < bounds.center.x && eventData.position.x > bounds.min.x + 75 && eventData.position.y < bounds.max.y - 100 && eventData.position.y > bounds.min.y + 100)
            {
                gameAPI.VibrateWeak();
                transform.position = eventData.position;
            }
            else
            {
                gameAPI.VibrateWeak();
                LeanTween.move(gameObject, shownImageSlot.position, 0.5f);
            }
        }
    }

    public void ScaleImagesDown()
    {
        LeanTween.scale(cardName, Vector3.zero, 0.25f);
        LeanTween.scale(gameObject, Vector3.zero, 0.25f);
        for (int i = 0; i < silhouettes.Length; i++)
        {
            LeanTween.scale(silhouettes[i], Vector3.zero, 0.25f);
        }
    }

    public void OpenCheckPointPanel()
    {
        checkPointPanel.SetActive(true);
        checkPointPanel.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
        LeanTween.scale(checkPointPanel, Vector3.one, 0.25f);
        Invoke("EnableContinuePlayingButton", .75f);
    }

    public void CloseCheckpointPanel()
    {
        StartCoroutine(CloseCheckPointPanelCoroutine());
    }

    IEnumerator CloseCheckPointPanelCoroutine()
    {
        LeanTween.scale(checkPointPanel, Vector3.zero, 0.25f);
        yield return new WaitForSeconds(0.25f);
        checkPointPanel.SetActive(false);
    }

    public void ResetCounter()
    {
        correctMatches = 0;
    }

    public void ChooseNewPackButtonClick()
    {
        StartCoroutine(ChooseNewPackButtonCoroutine());

    }

    IEnumerator ChooseNewPackButtonCoroutine()
    {
        ScaleImagesDown();
        LeanTween.scale(backButton, Vector3.zero, 0.25f);
        CloseCheckpointPanel();
        yield return new WaitForSeconds(0.25f);
        board.ClearBoard();
        packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
        packSelectionPanel.SetActive(true);
        LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
    }

    public async void CloseCheckpointPanelAndGenerateNewBoard()
    {
        StartCoroutine(CloseCheckPointPanelCoroutine());
        await board.GenerateRandomBoardAsync();
    }

    public void EnableContinuePlayingButton()
    {
        checkPointPanel.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = true;
    }

    public void OnBackButtonClick()
    {
        StartCoroutine(BackButtonClickCoroutine());
    }

    IEnumerator BackButtonClickCoroutine()
    {
        if (transform.localScale == Vector3.one && gameObject.GetComponent<Image>().sprite != null)
        {
            ResetCounter();
            ScaleImagesDown();
            LeanTween.scale(backButton, Vector3.zero, 0.25f);
            yield return new WaitForSeconds(0.25f);
            board.ClearBoard();
            packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
            packSelectionPanel.SetActive(true);
            LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
        }

    }
}

