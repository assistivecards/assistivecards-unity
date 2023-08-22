using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTrainUIController : MonoBehaviour
{
    GameAPI gameAPI;

    [Header ("Scripts")]
    [SerializeField] private PatternTrainBoardGenerator boardGenerator;
    [SerializeField] private PackSelectionPanel packSelectionPanelScript;

    [Header ("Panels")]
    [SerializeField] private GameObject levelChange;

    [Header ("UI Objects")]
    public GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject tutorial;

    private bool firstTime = true;
    public int reloadCount;
    public bool canGenerate;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        gameAPI.PlayMusic();
    }

    public void GameUIActivate()
    {
        if(canGenerate)
        {
            if(firstTime || gameAPI.GetTutorialPreference() == 1)
            {
                tutorial.SetActive(true);
            }
            gameUI.SetActive(true);
            backButton.SetActive(true);
            settingButton.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            loadingScreen.SetActive(false);
        }
    }

    public void GameUIDeactivate()
    {
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LevelEnding()
    {
        boardGenerator.ClearBoard();
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
    }

    public void LevelChangeScreenActivate()
    {
        LevelEnding();
        gameAPI.AddExp(gameAPI.sessionExp);
        levelChange.SetActive(true);
        LeanTween.scale(levelChange, Vector3.one * 0.6f, 0.3f);
        gameAPI.PlaySFX("Finished");
    }

    public void CloseLevelChangePanel()
    {
        LeanTween.scale(levelChange, Vector3.zero, 0.4f);
        gameAPI.ResetSessionExp();
        Invoke("LevelChangeDeactivate", 0.7f);
    }

    public void PackSelectionPanelActive()
    {
        gameUI.SetActive(false);
        gameAPI.ResetSessionExp();
        backButton.SetActive(false);
        settingButton.SetActive(true);
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
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
            loadingScreen.SetActive(true);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            settingButton.SetActive(false);
            backButton.SetActive(false);
        }
    }

    public void LevelEndCheck()
    {
        reloadCount ++;
        if(reloadCount < 5)
        {
            boardGenerator.ClearBoard();
            boardGenerator.GeneratedBoardAsync();
        }
        else
        {
            LevelChangeScreenActivate();
            reloadCount = 0;
        }
    }
}
