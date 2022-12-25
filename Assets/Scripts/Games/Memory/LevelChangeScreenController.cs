using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenController : MonoBehaviour
{
    [SerializeField] private PackageSelectManager packageSelectManager;
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private GameObject packSelectionPanel;
    public bool isOnSelect = false;
    public bool isOnContinue = false;

    public void ContinueClick()
    {
        isOnContinue = true;
        packageSelectManager.OnPackSelect();
        transitionPanel.SetActive(true);
    }
    public void SelectNewClick()
    {
        isOnSelect = true;
        packSelectionPanel.SetActive(true);
    }
}
