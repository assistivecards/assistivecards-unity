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
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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
            UIController.correctMatches++;
            Debug.Log("Correct Match!");
            for (int i = 0; i < scratchImages.Length; i++)
            {
                scratchImages[i].enabled = false;
            }
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            Invoke("ScaleCorrectCardUp", .25f);
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.30f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                UIController.Invoke("OpenCheckPointPanel", 1.30f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.30f);
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
