using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortCardUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject levelEndScreen;
    [SerializeField] private GameObject loadingScreen;
    
    public void GameUIActivate()
    {
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LevelEnd()
    {
        levelEndScreen.SetActive(true);
        LeanTween.scale(levelEndScreen, Vector3.one * 0.5f, 0.25f);
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void SelectNewPackClick()
    {
        backButton.SetActive(false);
        settingButton.SetActive(true);
        helloText.SetActive(true);
        packSelectionPanel.SetActive(true);
        gameUI.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LoadingScreenActivate()
    {
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
        gameUI.SetActive(false);
        loadingScreen.SetActive(true);
    }

    public void ResetScroll()
    {
        packSelectionPanel.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }

    public void LevelScreenContinue()
    {
        LeanTween.scale(levelEndScreen, Vector3.zero, 0.25f).setOnComplete(LoadingScreenActivate);
    }

    public void LevelScreenPackSelect()
    {
        LeanTween.scale(levelEndScreen, Vector3.zero, 0.25f).setOnComplete(SelectNewPackClick);
        ResetScroll();
    }

    private void LevelEndClose()
    {
        levelEndScreen.SetActive(false);
        packSelectionPanel.SetActive(true);

    }

}
