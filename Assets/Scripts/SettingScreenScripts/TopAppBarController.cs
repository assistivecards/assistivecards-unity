using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAppBarController : MonoBehaviour
{
    private GameObject backButton;
    private GameObject saveButton;

    public void BackButtonClicked()
    {
        LeanTween.scale(this.transform.parent.gameObject, Vector3.one*0.9f ,0.15f);
        Invoke("SceneSetActiveFalse", 0.15f);
    }

    private void SceneSetActiveFalse()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    private void SaveButtonClicked()
    {
        //save
    }
}
