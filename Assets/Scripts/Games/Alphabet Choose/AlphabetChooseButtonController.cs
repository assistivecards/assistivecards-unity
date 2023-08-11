using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetChooseButtonController : MonoBehaviour
{
    GameAPI gameAPI;
    public string firstLetter;
    [SerializeField] private AlphabetChooseBoardGenerator boardGenerator;
    [SerializeField] private AlphabetChooseUIController uıController;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void ButtonClick()
    {
        if(boardGenerator.firstLetter == firstLetter)
        {
            if(boardGenerator.levelCount < 4)
            {
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                Invoke("ReadCard", 0.2f);
                boardGenerator.levelCount++;
                boardGenerator.LevelEnding();
                boardGenerator.Invoke("CreateNewLevel", 1f);
            }
            else if(boardGenerator.levelCount == 4)
            {
                gameAPI.AddSessionExp();
                gameAPI.PlaySFX("Success");
                Invoke("ReadCard", 0.2f);
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

    private void ReadCard()
    {
        gameAPI.Speak(this.gameObject.name);
        Debug.Log(this.gameObject.name);
    }
}
