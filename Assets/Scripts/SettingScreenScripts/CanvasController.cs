using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject mainSettingsScreen;
    [SerializeField] private GameObject parentLockScreen;
    [SerializeField] private GameObject profileScreen;
    [SerializeField] private GameObject languageScreen;
    [SerializeField] private GameObject popUp;


    public void ParentLockButtonClick()
    {
        LeanTween.scale(popUp,  Vector3.one, 0.15f);
        parentLockScreen.SetActive(true);
    }

    public void ParentLockScreenClose()
    {
        LeanTween.scale(popUp, Vector3.one * 0.15f, 0.2f);
        parentLockScreen.SetActive(false);
    }

    public void ProfileButtonClick()
    {
        LeanTween.scale(profileScreen,  Vector3.one, 0.2f);
        profileScreen.SetActive(true);
    }

    public void LanguageButtonClick()
    {
        LeanTween.scale(languageScreen,  Vector3.one, 0.2f);
        languageScreen.SetActive(true);
    }

}
