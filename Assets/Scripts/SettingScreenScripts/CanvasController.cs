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


    public void ParentLockButtonClick()
    {
        parentLockScreen.SetActive(true);
    }

    public void ParentLockScreenClose()
    {
        parentLockScreen.SetActive(false);
    }

    public void ProfileButtonClick()
    {
        profileScreen.SetActive(true);
    }

    public void LanguageButtonClick()
    {
        languageScreen.SetActive(true);
    }

}
