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
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject levelProgressContainer;
    public static float onPointerUpTime;
    public static bool isPointerUp = false;

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
            gameAPI.AddSessionExp();
            backButton.GetComponent<Button>().interactable = false;
            correctMatches++;
            gameObject.GetComponent<Draggable>().enabled = false;
            LeanTween.move(gameObject, matchedImageTransform.position, 0.25f);
            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            // gameAPI.VibrateStrong();
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(matchedImageTransform.position);
            Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.5f);
            isMatched = false;
            if (correctMatches == 10)
            {
                // OpenCheckPointPanel();
                gameAPI.AddExp(gameAPI.sessionExp);
                Invoke("OpenCheckPointPanel", 1f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.5f);
        }

        else
        {
            //wrong match
            gameAPI.RemoveSessionExp();
            if (eventData.position.x < bounds.center.x && eventData.position.x > bounds.min.x + 75 && eventData.position.y < bounds.max.y - 100 && eventData.position.y > bounds.min.y + 100)
            {
                gameAPI.VibrateWeak();
                transform.position = eventData.position;
                isPointerUp = true;
                onPointerUpTime = Time.time;
            }
            else
            {
                // gameAPI.VibrateWeak();
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
        backButton.SetActive(false);
        checkPointPanel.transform.GetChild(1).GetComponent<Button>().interactable = false;
        LeanTween.scale(checkPointPanel, Vector3.one * 0.6f, 0.25f);
        gameAPI.PlaySFX("Finished");
        Invoke("EnableContinuePlayingButton", .75f);
    }

    public void CloseCheckpointPanel()
    {
        // checkPointPanel.SetActive(false);
        StartCoroutine(CloseCheckPointPanelCoroutine());
    }

    IEnumerator CloseCheckPointPanelCoroutine()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(checkPointPanel, Vector3.zero, 0.25f);
        yield return new WaitForSeconds(0.5f);
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
        gameAPI.ResetSessionExp();
        ScaleImagesDown();
        // LeanTween.scale(backButton, Vector3.zero, 0.25f);
        backButton.SetActive(false);
        CloseCheckpointPanel();
        yield return new WaitForSeconds(0.25f);
        board.ClearBoard();
        packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
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
        // checkPointPanel.SetActive(false);
        board.Invoke("GenerateRandomBoardAsync", 0.25f);
        // await board.GenerateRandomBoardAsync();
    }

    public void EnableContinuePlayingButton()
    {
        checkPointPanel.transform.GetChild(1).GetComponent<Button>().interactable = true;
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
        if (transform.localScale == Vector3.one && gameObject.GetComponent<Image>().sprite != null)
        {
            ResetCounter();
            gameAPI.ResetSessionExp();
            ScaleImagesDown();
            // LeanTween.scale(backButton, Vector3.zero, 0.25f);
            backButton.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            board.ClearBoard();
            packSelectionPanel.transform.localScale = new Vector3(0, 0, 0);
            var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
            rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
            packSelectionPanel.SetActive(true);
            LeanTween.scale(packSelectionPanel, Vector3.one, 0.25f);
            Invoke("EnableScrollRect", 0.26f);
            helloText.SetActive(true);
            speakerIcon.SetActive(true);
            homeButton.SetActive(true);
            levelProgressContainer.SetActive(true);
        }

    }

    public void PlayCorrectMatchAnimation()
    {
        matchedImageTransform.gameObject.SetActive(false);
        LeanTween.scale(gameObject, Vector3.one * 1.25f, .25f);
        // LeanTween.color(matchedImageTransform.gameObject.GetComponent<Image>().rectTransform, Color.white, .5f);
    }

    private void Update()
    {
        CalculateTimeElapsedSinceOnPointerUp();
    }

    public void CalculateTimeElapsedSinceOnPointerUp()
    {
        if (isPointerUp)
        {
            // Debug.Log(Time.time - onPointerUpTime);
            if ((Time.time - onPointerUpTime) >= 3)
            {
                LeanTween.move(gameObject, shownImageSlot.position, 0.5f);
                isPointerUp = false;
            }
        }
    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

    public void EnableBackButton()
    {
        backButton.SetActive(true);
    }

    public void DelayResetShownImagePosition()
    {
        Invoke("ResetShownImagePosition", 0.3f);
    }

    private void ResetShownImagePosition()
    {
        transform.position = shownImageSlot.position;
        isPointerUp = false;
    }
}
