using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerCardChain : MonoBehaviour
{
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject packSelectionScreen;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject selectNewPackButton;
    [SerializeField] private GameObject continueButton;

    public void InGameBar()
    {
        backButton.SetActive(true);
        helloText.SetActive(false);
        settingButton.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        helloText.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
        levelChangeScreen.SetActive(false);
    }

    public void LevelChangeActive()
    {
        settingButton.SetActive(false);
        backButton.SetActive(false);
        helloText.SetActive(false);
        levelChangeScreen.SetActive(true);
        LeanTween.scale(levelChangeScreen, Vector3.one * 0.6f, 0.5f);
    }

    public void CloseLevelChange()
    {
        LeanTween.scale(levelChangeScreen, Vector3.zero, 0.25f);
        Invoke("ResetLevelChangeScreen", 0.15f);
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
