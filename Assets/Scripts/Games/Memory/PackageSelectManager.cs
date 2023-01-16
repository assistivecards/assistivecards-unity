using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject difficultySelectionScreen;
    [SerializeField] private BoardGenerator boardGenerator;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private LevelChangeScreenController levelChangeScreenController;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    private string selectedPack;

    public void OnPackSelect()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            selectedPack = packSelectionPanel.selectedPackElement.name;

            levelChangeScreen.SetActive(false);

            if(levelChangeScreenController.isOnSelect)
            {
                //GenerateStylizedBoard();
                levelChangeScreenController.isOnSelect = false;
                difficultySelectionScreen.SetActive(true);
                //transitionScreen.SetActive(true);
            }
            else if(!levelChangeScreenController.isOnContinue && packSelectionScreenUIController.canGenerate)
            {
                difficultySelectionScreen.SetActive(true);
            }

            levelChangeScreenController.isOnContinue = false;
            boardGenerator.ResetBoard();
        }
    }

    public async void GenerateStylizedBoard()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            boardGenerator.ResetBoard();
            boardGenerator.CheckClones();
            await boardGenerator.CacheCards(selectedPack);
        }  
    }

    public void GenerateStylizedBoard(int cardCount)
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            boardGenerator.ResetBoard();
            boardGenerator.CheckClones();
            boardGenerator.cardNumber = cardCount;
        }
    }
}
