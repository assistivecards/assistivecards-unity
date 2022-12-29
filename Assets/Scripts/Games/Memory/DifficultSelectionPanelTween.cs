using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultSelectionPanelTween : MonoBehaviour
{
    [SerializeField] private GameObject easyButton;
    [SerializeField] private GameObject normalButton;
    [SerializeField] private GameObject hardButton;

    private void OnEnable() 
    {
        LeanTween.scale(easyButton, Vector3.one, 0.1f);
        LeanTween.scale(normalButton, Vector3.one, 0.1f);
        LeanTween.scale(hardButton, Vector3.one, 0.1f);
    }

    public void ButtonTween()
    {
        LeanTween.scale(easyButton, Vector3.one * 0.1f, 0.1f);
        LeanTween.scale(normalButton, Vector3.one * 0.1f, 0.1f);
        LeanTween.scale(hardButton, Vector3.one * 0.1f, 0.1f);

        Invoke("ClosePanel", 0.1f);
    }

    private void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }


}
