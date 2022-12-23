using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            board.packSlug = packSelectionPanelScript.selectedPackElement.name;
            packSelectionPanel.SetActive(false);
            helloText.SetActive(false);
            await board.CacheCards(board.packSlug);
            await board.GenerateRandomBoardAsync();
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

                    }
                    else
                    {
                        board.packSlug = packSelectionPanelScript.selectedPackElement.name;
                        packSelectionPanel.SetActive(false);
                        helloText.SetActive(false);
                        await board.CacheCards(board.packSlug);
                        await board.GenerateRandomBoardAsync();
                    }

                }
            }
        }
    }

}

