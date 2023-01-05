using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSelectionScreenUIController : MonoBehaviour
{
    private void OnEnable() 
    {
        OpenPackPanelTween();
    }

    public void OpenPackPanelTween()
    {
        LeanTween.scale(this.gameObject, Vector3.one, 0.1f);
    }

    public void ClosePackPanelTween()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.1f);
        Invoke("ClosePackPanel", 0.09f);
    }

    private void ClosePackPanel()
    {
        this.gameObject.SetActive(false);
    }
}
