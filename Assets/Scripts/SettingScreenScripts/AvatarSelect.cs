using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelect : MonoBehaviour
{
    private GameObject canvas;
    private OnboardingBackgroundController backgroundController;
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
        backgroundController = FindObjectOfType<OnboardingBackgroundController>().GetComponent<OnboardingBackgroundController>();
    }
    public void SelectAvatar()
    { 
        backgroundController.SetBackground2();
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
