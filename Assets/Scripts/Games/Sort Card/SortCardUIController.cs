using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;

    [SerializeField] private GameObject levelEndScreen;
    
    public void GameUIActivate()
    {
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
    }
    public void LevelEnd()
    {
        levelEndScreen.SetActive(true);
        gameUI.SetActive(false);
        backButton.SetActive(false);
        settingButton.SetActive(false);
        helloText.SetActive(false);
    }

}
