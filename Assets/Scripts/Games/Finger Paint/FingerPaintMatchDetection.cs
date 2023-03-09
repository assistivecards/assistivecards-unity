using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPaintMatchDetection : MonoBehaviour
{
    private PaintManager paintManager;
    [SerializeField] PaintImage[] coloredImages;
    private FingerPaintBoardGenerator board;

    private void Start()
    {
        paintManager = gameObject.GetComponent<PaintManager>();
        board = GameObject.Find("GamePanel").GetComponent<FingerPaintBoardGenerator>();
    }

    public void DetectMatch()
    {
        if (paintManager.isFullyColorized && gameObject.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
            for (int i = 0; i < coloredImages.Length; i++)
            {
                coloredImages[i].enabled = false;
            }

            Invoke("ScaleCorrectCardUp", .25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.30f);
            board.Invoke("GenerateRandomBoardAsync", 1.30f);
        }
        else if (paintManager.isFullyColorized && gameObject.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }

    public void ScaleCorrectCardUp()
    {
        LeanTween.scale(transform.parent.gameObject, Vector3.one * 1.25f, .25f);
    }

}
