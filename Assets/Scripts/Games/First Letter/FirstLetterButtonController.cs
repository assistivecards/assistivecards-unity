using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLetterButtonController : MonoBehaviour
{
    GameAPI gameAPI;
    public string letter;
    [SerializeField] private FirstLetterBoardGenerator boardGenerator;
    [SerializeField] private FirstLetterUIController uıController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void LetterButtonClick()
    {
        if(boardGenerator.firstLetter == letter)
        {
            if(boardGenerator.levelCount < 4)
            {
                gameAPI.PlaySFX("Success");
                gameAPI.AddSessionExp();
                boardGenerator.levelCount++;
                boardGenerator.LevelEnding();
                boardGenerator.Invoke("CreateNewLevel", 1f);
            }
            else if(boardGenerator.levelCount == 4)
            {
                gameAPI.PlaySFX("Success");
                gameAPI.AddSessionExp();
                boardGenerator.LevelEnding();
                boardGenerator.levelCount = 0;
                uıController.Invoke("LevelChangeScreenActivate", 1.2f);
            }
        }
        else
        {
            gameAPI.RemoveSessionExp();
            LeanTween.scale(this.gameObject, Vector3.zero, 0.5f);
        }
    }
}
