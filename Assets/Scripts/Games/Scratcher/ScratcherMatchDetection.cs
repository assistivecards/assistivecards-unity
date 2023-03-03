using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScratcherMatchDetection : MonoBehaviour
{
    private ScratchManager scratchManager;
    [SerializeField] ScratchImage[] scratchImages;
    private ScratcherUIController UIController;
    private ScratcherBoardGenerator board;

    private void Start()
    {
        scratchManager = gameObject.GetComponent<ScratchManager>();
        UIController = GameObject.Find("GamePanel").GetComponent<ScratcherUIController>();
        board = GameObject.Find("GamePanel").GetComponent<ScratcherBoardGenerator>();
    }

    public void DetectMatch()
    {
        if (scratchManager.isFullyScratched && gameObject.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
            for (int i = 0; i < scratchImages.Length; i++)
            {
                scratchImages[i].enabled = false;
            }
            UIController.backButton.GetComponent<Button>().interactable = false;
            Invoke("ScaleCorrectCardUp", .25f);
            board.Invoke("ScaleImagesDown", .75f);
            board.Invoke("ClearBoard", 1f);
            board.Invoke("GenerateRandomBoardAsync", 1f);
        }
        else if (scratchManager.isFullyScratched && gameObject.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }

    public void ScaleCorrectCardUp()
    {
        LeanTween.scale(transform.parent.gameObject, Vector3.one * 1.25f, .25f);
    }
}
