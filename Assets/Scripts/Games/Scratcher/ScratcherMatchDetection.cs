using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratcherMatchDetection : MonoBehaviour
{
    private ScratchManager scratchManager;

    private void Start()
    {
        scratchManager = gameObject.GetComponent<ScratchManager>();
    }

    public void DetectMatch()
    {
        if (scratchManager.isFullyScratched && gameObject.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
        }
        else if (scratchManager.isFullyScratched && gameObject.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }
}
