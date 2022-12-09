using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelect : MonoBehaviour
{
    private GameObject canvas;
    private CanvasController canvasController;
    private GameObject avatarSelection;


    private void Awake()
    {
        avatarSelection = GameObject.FindGameObjectWithTag("avatarSelection");

    }
    private void Start() 
    {
        canvas = GameObject.Find("Canvas");
        canvasController = canvas.GetComponent<CanvasController>();
    }
    public void SelectAvatar()
    {
        if(avatarSelection != null)
        {
            LeanTween.scale(avatarSelection, Vector3.one * 0.9f, 0.15f);
        }

        Invoke("SceneSetActiveFalse", 0.15f);
    }

    private void SceneSetActiveFalse()
    {
        if(avatarSelection != null)
        {
            avatarSelection.SetActive(false);

        }
    }
}
