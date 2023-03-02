using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScratcherUIController : MonoBehaviour
{
    [SerializeField] ScratcherBoardGenerator board;
    public GameObject backButton;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnBackButtonClick()
    {
        StartCoroutine(BackButtonClickCoroutine());
    }

    IEnumerator BackButtonClickCoroutine()
    {
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

    }

    public void EnableBackButton()
    {
        backButton.SetActive(true);
    }

    public void EnableScrollRect()
    {
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
    }

    public void ResetScrollRect()
    {
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }

}
