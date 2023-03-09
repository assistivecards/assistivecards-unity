using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FingerPaintMatchDetection : MonoBehaviour
{
    private PaintManager paintManager;
    [SerializeField] PaintImage[] coloredImages;

    private void Start()
    {
        paintManager = gameObject.GetComponent<PaintManager>();
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
        }
        else if (paintManager.isFullyColorized && gameObject.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }

}
