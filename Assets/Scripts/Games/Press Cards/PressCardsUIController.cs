using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressCardsUIController : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    public GameObject backButton;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject levelProgressContainer;
    [SerializeField] GameObject checkPointPanel;
    private GameAPI gameAPI;
    [SerializeField] PressCardsMatchDetection matchDetector;
    private bool firstTime = true;
    [SerializeField] GameObject tutorial;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

    public void TutorialSetActive()
    {
        if (firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }

    public void OpenCheckPointPanel()
    {
        checkPointPanel.SetActive(true);
        backButton.SetActive(false);
        checkPointPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
        LeanTween.scale(checkPointPanel, Vector3.one * 0.6f, 0.25f);
        gameAPI.PlaySFX("Finished");
        Invoke("EnableContinuePlayingButton", .75f);
    }

    public void CloseCheckpointPanel()
    {
        StartCoroutine(CloseCheckPointPanelCoroutine());
    }

    IEnumerator CloseCheckPointPanelCoroutine()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(checkPointPanel, Vector3.zero, 0.25f);
        yield return new WaitForSeconds(0.5f);
        checkPointPanel.SetActive(false);
    }

    public void ChooseNewPackButtonClick()
    {
        StartCoroutine(ChooseNewPackButtonCoroutine());

    }

    IEnumerator ChooseNewPackButtonCoroutine()
    {
        gameAPI.ResetSessionExp();
        board.ScaleImagesDown();
        backButton.SetActive(false);
        CloseCheckpointPanel();
        yield return new WaitForSeconds(0.25f);
        board.ClearBoard();
        packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
        ResetScrollRect();
        packSelectionPanel.SetActive(true);
        LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
        helloText.SetActive(true);
        speakerIcon.SetActive(true);
        homeButton.SetActive(true);
        levelProgressContainer.SetActive(true);
        Invoke("EnableScrollRect", 0.26f);
    }

    public void CloseCheckpointPanelAndGenerateNewBoard()
    {
        StartCoroutine(CloseCheckPointPanelCoroutine());
        board.Invoke("GenerateRandomBoardAsync", 0.25f);
    }

    public void EnableContinuePlayingButton()
    {
        checkPointPanel.transform.GetChild(1).GetComponent<Button>().interactable = true;
    }

    public void EnableBackButton()
    {
        backButton.SetActive(true);
    }

    public void ResetCounter()
    {
        matchDetector.correctMatches = 0;
    }

    public void ResetScrollRect()
    {
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }

    public void OnBackButtonClick()
    {
        if (Input.touchCount == 1)
        {
            StartCoroutine(BackButtonClickCoroutine());
        }
    }

    IEnumerator BackButtonClickCoroutine()
    {
        ResetCounter();
        gameAPI.ResetSessionExp();
        // board.ClearUniqueCards();
        board.ScaleImagesDown();
        backButton.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        board.ClearBoard();
        packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
        ResetScrollRect();
        packSelectionPanel.SetActive(true);
        LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
        Invoke("EnableScrollRect", 0.26f);
        helloText.SetActive(true);
        speakerIcon.SetActive(true);
        homeButton.SetActive(true);
        levelProgressContainer.SetActive(true);

    }
}
