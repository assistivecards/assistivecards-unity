using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushLevelControl : MonoBehaviour
{
    [SerializeField] private CardCrushFillGrid fillGrid;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject packSelectionPanel;
    [SerializeField] private GameObject contunieButton;
    [SerializeField] private GameObject selectNewButton;

    public bool isOnSelect = false;
    public bool isOnContinue = false;
    public bool isOnLevelChange = false;

    private void OnEnable() 
    {
        isOnLevelChange = true;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.15f);
        fillGrid.scoreInt = 0;
        fillGrid.ResetGrid();
        fillGrid.isOnRefill = false;
    }

    public void ContinueClick()
    {
        isOnContinue = true;
        isOnLevelChange = false;

        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);
        Invoke("ClosePanel", 0.2f);
    }

    public void SelectNewClick()
    {
        isOnSelect = true;
        isOnLevelChange = false;

        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);
        Invoke("ClosePanel", 0.2f);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);

        LeanTween.scale(contunieButton, Vector3.one, 0.01f);
        LeanTween.scale(selectNewButton, Vector3.one, 0.01f);
    }
}