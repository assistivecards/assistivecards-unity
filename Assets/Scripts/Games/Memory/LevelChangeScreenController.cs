using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenController : MonoBehaviour
{
    [SerializeField] private PackageSelectManager packageSelectManager;
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject contunieButton;
    [SerializeField] private GameObject selectNewButton;

    public bool isOnSelect = false;
    public bool isOnContinue = false;
    public bool isOnLevelChange = false;

    private void OnEnable() 
    {
        isOnLevelChange = true;
        LeanTween.scale(contunieButton, Vector3.one, 0.05f);
        LeanTween.scale(selectNewButton, Vector3.one, 0.05f);
    }

    public void ContinueClick()
    {
        isOnContinue = true;
        packageSelectManager.OnPackSelect();
        isOnLevelChange = false;

        LeanTween.scale(contunieButton, Vector3.one * 0.1f, 0.05f);
        LeanTween.scale(selectNewButton, Vector3.one * 0.1f, 0.05f);

        Invoke("ClosePanel", 0.05f);
        transitionPanel.SetActive(true);
    }

    public void SelectNewClick()
    {
        isOnSelect = true;
        isOnLevelChange = false;

        LeanTween.scale(contunieButton, Vector3.one * 0.1f, 0.05f);
        LeanTween.scale(selectNewButton, Vector3.one * 0.1f, 0.05f);

        Invoke("ClosePanel", 0.05f);
        packSelectionPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
