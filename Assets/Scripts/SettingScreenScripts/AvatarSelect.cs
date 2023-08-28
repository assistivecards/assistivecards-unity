using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelect : MonoBehaviour
{
    private GameObject canvas;
    public GameObject practiceReminder;
    private CanvasController canvasController;
    private GameObject avatarSelection;


    private void Awake()
    {
        avatarSelection = GameObject.FindGameObjectWithTag("avatarSelection");
    }
    private void Start()
    {
        canvas = GameObject.Find("Settings");
        canvasController = canvas.GetComponent<CanvasController>();
    }
    public void SelectAvatar()
    {
        if (avatarSelection != null)
        {
            LeanTween.scale(avatarSelection, Vector3.one * 0.9f, 0.15f);
        }
        LeanTween.scale(practiceReminder, Vector3.one * 0.9f, 0f);
        Invoke("SceneSetActiveFalse", 0.15f);
    }

    private void SceneSetActiveFalse()
    {
        if (avatarSelection != null)
        {
            avatarSelection.SetActive(false);
        }
    }
}
