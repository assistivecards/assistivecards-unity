using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;

    [Header("Screens")]
    [SerializeField] private GameObject levelScreen;
    [SerializeField] private GameObject grid;

    private void Update() 
    {
        if(boardCreatorComplete.levelEnded)
        {
            boardCreatorComplete.ResetLevel();
            levelScreen.SetActive(true);
        }
    }
}
