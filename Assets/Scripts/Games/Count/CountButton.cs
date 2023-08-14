using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountButton : MonoBehaviour
{
    GameAPI gameAPI;
    public int value;
    private CountGenerateBoard generateBoard;
    private CountUIController uıController;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        generateBoard = FindObjectOfType<CountGenerateBoard>();
        uıController = FindObjectOfType<CountUIController>();
    }


    public void CountButtonClick()
    {
        if(value == generateBoard.countNum + 1)
        {
            if(generateBoard.levelCount >= 3)
            {
                gameAPI.AddSessionExp();
                FinishedSound();
                generateBoard.ScaleUpLevelEndCard();
                generateBoard.Invoke("ScaleDownLevelEndCard", 0.6f);
                Invoke("CallLevelEnd", 1f);
                generateBoard.levelCount = 0;
            }
            else if(generateBoard.levelCount < 3)
            {
                gameAPI.AddSessionExp();
                LevelEndAnimation();
                generateBoard.GeneratedBoardAsync();
                FinishedSound();
                generateBoard.levelCount++;
            }
        }
        else
        {
            gameAPI.RemoveSessionExp();
            LeanTween.scale(this.gameObject, Vector3.one * 1.5f, 0.25f).setOnComplete(ScaleDown);
        }
    }

    private void LevelEndAnimation()
    {
        generateBoard.ScaleUpLevelEndCard();
        gameAPI.Speak(generateBoard.cardLocalNames[generateBoard.randomValueList[0]]);
        generateBoard.ClearBoard();
    }

    private void FinishedSound()
    {
        gameAPI.PlaySFX("Finished");
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
