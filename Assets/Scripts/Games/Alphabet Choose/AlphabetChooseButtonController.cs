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
            uıController.LevelChangeScreenActivate();
            Debug.Log("HERE");
        }
        else
        {
            LeanTween.scale(this.gameObject, Vector3.zero, 0.5f);
        }
    }
}
