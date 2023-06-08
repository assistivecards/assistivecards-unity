using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingUIController : MonoBehaviour
{
    [SerializeField] private GameObject rod;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    [SerializeField] private GameObject loadingScreen;

    public void GameUIActivate()
    {
        rod.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
        loadingScreen.SetActive(false);
    }
}
