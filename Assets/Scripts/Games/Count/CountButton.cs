using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountButton : MonoBehaviour
{
    public int value;
    private CountGenerateBoard generateBoard;
    private CountUIController uıController;

    private void OnEnable() 
    {
        generateBoard = FindObjectOfType<CountGenerateBoard>();
        uıController = FindObjectOfType<CountUIController>();
    }


    public void CountButtonClick()
    {
        if(value == generateBoard.countNum + 1)
        {
            Invoke("CallLevelEnd", 0.25f);
        }
        else
        {
            LeanTween.scale(this.gameObject, Vector3.one * 1.5f, 0.25f).setOnComplete(ScaleDown);
        }
    }

    private void CallLevelEnd()
    {
        generateBoard.ClearBoard();
        uıController.LevelChangeScreenActivate();
    }

    private void ScaleDown()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.20f);
    }
}
