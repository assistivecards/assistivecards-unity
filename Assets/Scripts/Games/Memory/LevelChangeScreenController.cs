using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private PackageSelectManager packageSelectManager;
    [SerializeField] private GameObject transitionPanel;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject contunieButton;
    [SerializeField] private GameObject selectNewButton;

    public bool isOnSelect = false;
    public bool isOnContinue = false;
    public bool isOnLevelChange = false;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        isOnLevelChange = true;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.15f);
    }

    public void ContinueClick()
    {
        isOnContinue = true;
        packageSelectManager.OnPackSelect();
        isOnLevelChange = false;

        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);

        Invoke("ClosePanel", 0.2f);
        transitionPanel.SetActive(true);
    }

    public void SelectNewClick()
    {
        isOnSelect = true;
        isOnLevelChange = false;

        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);

        Invoke("ClosePanel", 0.2f);
        packSelectionPanel.SetActive(true);
    }

    private void ClosePanel()
    {
        gameAPI.ResetSessionExp();
        this.gameObject.SetActive(false);
        LeanTween.scale(contunieButton, Vector3.one, 0.01f);
        LeanTween.scale(selectNewButton, Vector3.one, 0.01f);
    }
}
