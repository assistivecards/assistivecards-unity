using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Board board;
    [SerializeField] PackSelectionPanel packSelectionPanelScript;
    [SerializeField] GameObject packSelectionPanel;
    [SerializeField] GameObject settingButton;
    [SerializeField] CanvasController canvasController;
    GameAPI gameAPI;
    [SerializeField] GameObject helloText;
    [SerializeField] GameObject fadeInPanel;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public async void OnPackSelect()
    {
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5")
        {
            GenerateCorrespondingRandomBoard();
        }
        else
        {
            for (int i = 0; i < gameAPI.cachedPacks.packs.Length; i++)
            {
                if (gameAPI.cachedPacks.packs[i].slug == packSelectionPanelScript.selectedPackElement.name)
                {
                    if (gameAPI.cachedPacks.packs[i].premium == 1)
                    {
                        Debug.Log("Seçilen paket premium");
                        // canvasController.GetComponent<CanvasController>().StartFadeAnim();
                        fadeInPanel.SetActive(true);
                        settingButton.GetComponent<SettingScreenButton>().SettingButtonClickFunc();
                        canvasController.GetComponent<CanvasController>().PremiumPromoButtonClick();
                        Invoke("ResetScrollPosition", 0.3f);

                    }
                    else
                    {
                        GenerateCorrespondingRandomBoard();
                    }

                }
            }
        }
    }

    private async void GenerateCorrespondingRandomBoard()
    {
        board.packSlug = packSelectionPanelScript.selectedPackElement.name;
        packSelectionPanel.transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
        LeanTween.scale(packSelectionPanel, Vector3.zero, 0.25f);
        Invoke("ClosePackSelectionPanel", 0.25f);
        helloText.SetActive(false);
        await board.CacheCards(board.packSlug);
        // board.Invoke("GenerateRandomBoardAsync", 0.3f);
        await board.GenerateRandomBoardAsync();
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

