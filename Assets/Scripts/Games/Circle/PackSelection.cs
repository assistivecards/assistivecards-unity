using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class PackSelection : MonoBehaviour
{
    [SerializeField] BoardGeneration boardGeneration;
    [SerializeField] PackSelectionPanel packSelectionPanelScript;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject settingButton;
    [SerializeField] CanvasController canvasController;
    GameAPI gameAPI;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject speakerIcon;
    [SerializeField] GameObject fadeInPanel;
    [SerializeField] PackSelectionScreenUIController packSelectionScreenUIController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async void GenerateCorrespondingRandomBoard()
    {
        if (packSelectionScreenUIController.canGenerate)
        {
            boardGeneration.packSlug = packSelectionPanelScript.selectedPackElement.name;
            packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
            LeanTween.scale(packSelectionPanel, Vector3.zero, 0.25f);
            Invoke("ClosePackSelectionPanel", 0.5f);
            helloText.SetActive(false);
            speakerIcon.SetActive(false);
            await boardGeneration.CacheCards(boardGeneration.packSlug);
            // board.Invoke("GenerateRandomBoardAsync", 0.3f);
            await boardGeneration.GenerateRandomBoardAsync();
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
