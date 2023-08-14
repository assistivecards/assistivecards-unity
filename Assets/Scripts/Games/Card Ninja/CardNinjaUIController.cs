using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardNinjaUIController : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Scripts")]
    [SerializeField] private PackSelectionPanel packSelectionPanelScript;
    [SerializeField] private CardNinjaBoardGenerator boardGenerator;
    [SerializeField] private CardNinjaCutController cutController;

    [Header ("Panels")]
    [SerializeField] private GameObject levelChange;

    [Header ("UI Objects")]
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject cutPrefab;
    [SerializeField] public GameObject cutText;

    [SerializeField] private GameObject tutorial;
    public bool levelEnd;
    private bool firstTime = true;
    public bool canGenerate;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

    public void TutorialSetActive()
    {
        if(canGenerate)
        {
            if(firstTime || gameAPI.GetTutorialPreference() == 1)
            {
                tutorial.SetActive(true);
            }
            firstTime = false;
        }
    }

    public void GameUIActivate()
    {
        if(canGenerate)
        {
            cutText.SetActive(true);
            levelEnd = false;
            loadingScreen.SetActive(false);
            backButton.SetActive(true);
            settingButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
        }
    }

    public void BackButtonClick()
    {
        levelEnd = true;
        boardGenerator.ClearBoard();
        cutText.SetActive(false);
        cutController.ResetLevel();
    }

    public void ReloadLevel()
    {
        levelEnd = true;
        boardGenerator.ClearBoard();
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
    }

    public void LevelEnd()
    {
        gameAPI.AddExp(gameAPI.sessionExp);
        cutText.SetActive(false);
        levelEnd = true;
        boardGenerator.ClearBoard();
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        levelChange.SetActive(true);
        LeanTween.scale(levelChange, Vector3.one * 0.6f, 0.5f);
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

    public void PackSelectionPanelActive()
    {
        gameAPI.ResetSessionExp();
        cutText.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(true);
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
        packSelectionScreen.SetActive(true);
    }

    public void CloseLevelChangePanel()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(levelChange, Vector3.zero, 0.5f);
        Invoke("LevelChangeDeactivate", 1f);
    }

    public void LevelChangeDeactivate()
    {
        levelChange.SetActive(false);
    }

    public void ResetScroll()
    {
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }

    public void LoadingScreenActivation()
    {
        if(canGenerate)
        {
            cutText.SetActive(false);
            loadingScreen.SetActive(true);
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            settingButton.SetActive(false);
        }
    }
}
