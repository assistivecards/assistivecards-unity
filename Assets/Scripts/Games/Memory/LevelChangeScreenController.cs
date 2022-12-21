using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenController : MonoBehaviour
{
    [SerializeField] private PackageSelectManager packageSelectManager;
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private GameObject packSelectionPanel;

    public void ContinueClick()
    {
        packageSelectManager.OnPackSelect();
        transitionPanel.SetActive(true);
        transitionPanel.GetComponent<TransitionScreenManager>().loadingBar.value = 0;
    }
    public void SelectNewClick()
    {
        transitionPanel.GetComponent<TransitionScreenManager>().loadingBar.value = 0;
        transitionPanel.SetActive(false);
        packSelectionPanel.SetActive(true);
    }
}
