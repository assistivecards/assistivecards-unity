using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultSelectionPanelTween : MonoBehaviour
{
    [SerializeField] private GameObject easyButton;
    [SerializeField] private GameObject normalButton;
    [SerializeField] private GameObject hardButton;
    public bool isOnDifficultyScene = false;

    private void OnEnable() 
    {
        isOnDifficultyScene = true;
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.15f);
    }

    public void ButtonTween()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);
        isOnDifficultyScene = false;
        Invoke("ClosePanel", 0.2f);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);

        LeanTween.scale(easyButton, Vector3.one, 0.01f);
        LeanTween.scale(normalButton, Vector3.one, 0.01f);
        LeanTween.scale(hardButton, Vector3.one, 0.01f);
    }


}
