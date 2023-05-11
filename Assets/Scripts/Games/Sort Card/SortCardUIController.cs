using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject helloText;
    
    public void GameUIActivate()
    {
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
        helloText.SetActive(false);
    }

}
