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


    public void InGameBar()
    {
        backButton.SetActive(true);
        helloText.SetActive(false);
        settingButton.SetActive(true);
    }

    public void PackSelectionActive()
    {
        ResetScroll();
        helloText.SetActive(true);
        settingButton.SetActive(true);
        backButton.SetActive(false);
        packSelectionScreen.SetActive(true);
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
    }

    public void ResetScroll()
    {
        packSelectionScreen.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
