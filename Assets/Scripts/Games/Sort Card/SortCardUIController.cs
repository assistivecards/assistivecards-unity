using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortCardUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private PackSelectionPanel packSelectionPanelScript;
    [SerializeField] private SortCardBoardGenerator boardGenerator;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelEndScreen;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] GameObject tutorial;
    private bool firstTime = true;
    public int reloadCount;
    public bool canGenerate;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void TutorialSetActive()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        firstTime = false;
    }
    
    public void GameUIActivate()
    {
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LevelEnd()
    {
        if(reloadCount < 4)
        {
            reloadCount++;
            LoadingScreenActivate();
            boardGenerator.GeneratStylized();
        }
        else
        {
            levelEndScreen.SetActive(true);
            LeanTween.scale(levelEndScreen, Vector3.one * 0.5f, 0.5f);
            gameUI.SetActive(false);
            backButton.SetActive(false);
            settingButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            loadingScreen.SetActive(false);
            gameAPI.AddExp(gameAPI.sessionExp);
            reloadCount = 0;
        }
    }

    public void SelectNewPackClick()
    {
        backButton.SetActive(false);
        settingButton.SetActive(true);
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
        packSelectionPanel.SetActive(true);
        gameUI.SetActive(false);
        loadingScreen.SetActive(false);
        Invoke("SetLevelChangeScreenFalse", 1f);
    }
    
    public void DetectPremium()
    {
        if (gameAPI.GetPremium() == "A5515T1V3C4RD5")
        {
            canGenerate = true;
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
                        canGenerate = false;
                    }
                    else
                    {
                        Debug.Log("Seçilen paket premium değil");
                        canGenerate = true;
                    }

                }
            }
        }
    }

    public void LoadingScreenActivate()
    {
        if(canGenerate)
        {
            backButton.SetActive(false);
            settingButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            gameUI.SetActive(false);
            loadingScreen.SetActive(true);
        }
        Invoke("SetLevelChangeScreenFalse", 1f);
    }

    public void ResetScroll()
    {
        reloadCount = 0;
        gameAPI.ResetSessionExp();
        packSelectionPanel.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }

    public void LevelScreenContinue()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(levelEndScreen, Vector3.zero, 0.25f).setOnComplete(LoadingScreenActivate);
    }

    public void LevelScreenPackSelect()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(levelEndScreen, Vector3.zero, 0.25f).setOnComplete(SelectNewPackClick);
        ResetScroll();
    }

    private void LevelEndClose()
    {
        levelEndScreen.SetActive(false);
        packSelectionPanel.SetActive(true);

    }

    private void SetLevelChangeScreenFalse()
    {
        levelEndScreen.SetActive(false);
    }
}
