using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizePuzzleUIController : MonoBehaviour
{
    [SerializeField] SizePuzzleBoardGenerator board;
    public GameObject backButton;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject levelProgressContainer;
    [SerializeField] GameObject checkPointPanel;
    private GameAPI gameAPI;
    public int correctMatches;
    [SerializeField] GameObject tutorial;
    private bool firstTime = true;
    public int checkpointFrequency;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

    public void OpenCheckPointPanel()
    {
        checkPointPanel.SetActive(true);
        backButton.SetActive(false);
        checkPointPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
        LeanTween.scale(checkPointPanel, Vector3.one * 0.6f, 0.25f);
        gameAPI.PlaySFX("Finished");
        Invoke("EnableContinuePlayingButton", .75f);
        TutorialSetDeactive();
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
        correctMatches = 0;
    }

    public void ResetScrollRect()
    {
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }

    public void OnBackButtonClick()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
           StartCoroutine(BackButtonClickCoroutine());
        }
        else
        {
            if (SizePuzzleBoardGenerator.isBackAfterSignOut)
            {
                StartCoroutine(BackButtonClickCoroutine());
            }
        }
    }

    IEnumerator BackButtonClickCoroutine()
    {
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            board.cardParents[i].GetComponent<SizePuzzleMatchDetection>().enabled = false;
        }
        ResetCounter();
        gameAPI.ResetSessionExp();
        board.ClearUniqueCards();
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
        TutorialSetDeactive();
    }

    public void TutorialSetActive()
    {
        if (firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }

    public void TutorialSetDeactive()
    {
        tutorial.SetActive(false);
    }

}
