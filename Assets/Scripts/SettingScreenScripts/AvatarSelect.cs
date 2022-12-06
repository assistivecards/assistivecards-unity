using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelect : MonoBehaviour
{
    private GameObject avatarSelection;
    private GameObject avatarSelectionSettings;


    private void Awake()
    {
        avatarSelectionSettings = GameObject.FindGameObjectWithTag("avatarSelectionSettings");
        avatarSelection = GameObject.FindGameObjectWithTag("avatarSelection");

    }
    public void SelectAvatar()
    {
        if(avatarSelection != null)
        {
            LeanTween.scale(avatarSelection, Vector3.one * 0.9f, 0.15f);
            Debug.Log("!");
        }
        else if(avatarSelectionSettings != null)
        {
            LeanTween.scale(avatarSelectionSettings, Vector3.one * 0.9f, 0.15f);
        }

        Invoke("SceneSetActiveFalse", 0.15f);
    }

    private void SceneSetActiveFalse()
    {
        if(avatarSelection != null)
        {
            avatarSelection.SetActive(false);

        }
        else if(avatarSelectionSettings != null)
        {
            avatarSelectionSettings.SetActive(false);
        }
    }
}
