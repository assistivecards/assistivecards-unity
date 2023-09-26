using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class StackCardsPackSelection : MonoBehaviour
{
    [SerializeField] StackCardsBoardGenerator boardGenerator;
    [SerializeField] PackSelectionPanel packSelectionPanelScript;
    [SerializeField] GameObject packSelectionPanel;
    GameAPI gameAPI;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject levelProgressContainer;
    [SerializeField] PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] GameObject loadingPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async void GenerateCorrespondingRandomBoard()
    {
        if (Input.touchCount == 1)
        {
            if (packSelectionScreenUIController.canGenerate)
            {
                boardGenerator.packSlug = packSelectionPanelScript.selectedPackElement.name;
                packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
                LeanTween.scale(packSelectionPanel, Vector3.zero, 0.25f);
                loadingPanel.SetActive(true);
                Invoke("ClosePackSelectionPanel", 0.5f);
                helloText.SetActive(false);
                speakerIcon.SetActive(false);
                homeButton.SetActive(false);
                levelProgressContainer.SetActive(false);
                await boardGenerator.CacheCards(boardGenerator.packSlug);
                await boardGenerator.GenerateRandomBoardAsync();
            }
        }

    }

    private void ClosePackSelectionPanel()
    {
        packSelectionPanel.SetActive(false);
    }

    public void ResetScrollPosition()
    {
        var rt = packSelectionPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, 0);
    }
}
