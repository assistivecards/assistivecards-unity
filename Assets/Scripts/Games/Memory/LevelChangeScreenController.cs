using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenController : MonoBehaviour
{
    [SerializeField] private PackageSelectManager packageSelectManager;
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private GameObject packSelectionPanel;
    public bool isOnSelect = false;

    public void ContinueClick()
    {
        packageSelectManager.OnPackSelect();
        transitionPanel.SetActive(true);
    }
    public void SelectNewClick()
    {
        isOnSelect = true;
        transitionPanel.SetActive(false);
        packSelectionPanel.SetActive(true);
    }
}
