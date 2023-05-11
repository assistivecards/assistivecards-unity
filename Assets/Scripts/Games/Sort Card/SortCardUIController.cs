using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCardUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingButton;
    
    public void GameUIActivate()
    {
        gameUI.SetActive(true);
        backButton.SetActive(true);
        settingButton.SetActive(true);
    }

}
