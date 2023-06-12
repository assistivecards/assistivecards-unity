using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingUIController : MonoBehaviour
{
    [Header ("Scripts")]
    [SerializeField] private CardFishingRodController rodController;
    [SerializeField] private CardFishingBoardGenerator boardGenerator;

    [Header ("Panels")]
    [SerializeField] private GameObject levelChange;

    [Header ("UI Objects")]
    [SerializeField] private GameObject rod;
    [SerializeField] private GameObject collectText;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject loadingScreen;

    public void GameUIActivate()
    {
        rod.SetActive(true);
        collectText.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void LevelChangeScreenActivate()
    {
        boardGenerator.ClearBoard();
        rod.SetActive(false);
        collectText.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
        levelChange.SetActive(true);
        LeanTween.scale(levelChange, Vector3.one * 0.5f, 0.1f);
    }
}
