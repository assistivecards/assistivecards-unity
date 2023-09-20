using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerBucket : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private AccessibilityScreen accessibilityScreen;
    [SerializeField] private PackSelectionPanel packSelectionPanelScript;

    [Header ("UI Elements")]
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject levelProgressContainer;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject selectNewPackButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject collectCount;
    [SerializeField] private GameObject cardImage;
    [SerializeField] private GameObject tutorial;


    private bool firstTime = true;
    public bool canGenerate;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void InGame()
    {
        if(firstTime || gameAPI.GetTutorialPreference() == 1)
        {
            tutorial.SetActive(true);
        }
        backButton.SetActive(true);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        settingButton.SetActive(true);
        levelChangeScreen.SetActive(false);
        collectCount.SetActive(true);
        cardImage.SetActive(true);
        firstTime = false;
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        helloText.SetActive(true);
        levelProgressContainer.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
        levelChangeScreen.SetActive(false);
        collectCount.SetActive(false);
        cardImage.SetActive(false);
        gameAPI.ResetSessionExp();
    }

    public void LevelChangeActive()
    {
        gameAPI.AddExp(gameAPI.sessionExp);
        settingButton.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(false);
        levelProgressContainer.SetActive(false);
        levelChangeScreen.SetActive(true);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.6f, 0.5f);
        collectCount.SetActive(false);
        cardImage.SetActive(false);
    }

    public void TransitionScreen()
    {
        if(canGenerate)
        {
            backButton.SetActive(false);
            helloText.SetActive(false);
            levelProgressContainer.SetActive(false);
            transitionScreen.SetActive(true);
            collectCount.SetActive(false);
            cardImage.SetActive(false);
        }
    }

    public void CloseTransitionScreen()
    {
        transitionScreen.SetActive(false);
    }

    public void CloseLevelChange()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(levelChangeScreen, Vector3.zero, 0.25f);
        Invoke("ResetLevelChangeScreen", 0.15f);
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

    private void ResetLevelChangeScreen()
    {
        LeanTween.scale(selectNewPackButton, Vector3.one, 0.15f);
        LeanTween.scale(continueButton, Vector3.one, 0.15f);
    }

    public void ResetScroll()
    {
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
