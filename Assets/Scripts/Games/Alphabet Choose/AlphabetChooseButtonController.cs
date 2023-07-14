using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetChooseButtonController : MonoBehaviour
{
    public string letter;
    [SerializeField] private AlphabetChooseBoardGenerator boardGenerator;
    [SerializeField] private AlphabetChooseUIController uıController;

    public void LetterButtonClick()
    {
        if(boardGenerator.firstLetter == letter)
        {
            if(boardGenerator.levelCount < 3)
            {
                boardGenerator.levelCount++;
                boardGenerator.LevelEnding();
            }
            else if(boardGenerator.levelCount == 3)
            {
                boardGenerator.LevelEnding();
                boardGenerator.levelCount = 0;
                uıController.Invoke("LevelChangeScreenActivate", 1.2f);
            }
        }
        else
        {
            LeanTween.scale(this.gameObject, Vector3.zero, 0.5f);
        }
    }
}
