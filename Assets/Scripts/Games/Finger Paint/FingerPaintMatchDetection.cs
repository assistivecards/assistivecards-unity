using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPaintMatchDetection : MonoBehaviour
{
    private PaintManager paintManager;
    [SerializeField] PaintImage[] coloredImages;
    private FingerPaintBoardGenerator board;
    private FingerPaintUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        paintManager = gameObject.GetComponent<PaintManager>();
        board = GameObject.Find("GamePanel").GetComponent<FingerPaintBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<FingerPaintUIController>();
    }

    public void DetectMatch()
    {
        if (paintManager.isFullyColorized && gameObject.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
            gameAPI.AddSessionExp();
            UIController.correctMatches++;
            for (int i = 0; i < coloredImages.Length; i++)
            {
                coloredImages[i].enabled = false;
            }

            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(transform.parent.position);
            Invoke("ScaleCorrectCardUp", .25f);
            board.Invoke("ReadCard", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.30f);
            if (UIController.correctMatches == UIController.checkpointFrequency)
            {
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.30f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.30f);
        }
        else if (paintManager.isFullyColorized && gameObject.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
            gameAPI.RemoveSessionExp();
        }
    }

    public void ScaleCorrectCardUp()
    {
        LeanTween.scale(transform.parent.gameObject, Vector3.one * 1.25f, .25f);
    }

}
