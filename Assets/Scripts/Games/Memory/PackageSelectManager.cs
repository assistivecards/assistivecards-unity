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
    private string selectedPack;

    public async void OnPackSelect()
    {
        boardGenerator.ResetBoard();

        selectedPack = packSelectionPanel.selectedPackElement.name;

        levelChangeScreen.SetActive(false);

        if(levelChangeScreenController.isOnSelect)
        {
            GenerateStylizedBoard();
            levelChangeScreenController.isOnSelect = false;
            transitionScreen.SetActive(true);
        }
        else if(!levelChangeScreenController.isOnContinue)
        {
            difficultySelectionScreen.SetActive(true);
        }

        levelChangeScreenController.isOnContinue = false;
    }

    public async void GenerateStylizedBoard()
    {
        boardGenerator.ResetBoard();
        boardGenerator.CheckClones();
        await boardGenerator.CacheCards(selectedPack);
    }

    public async void GenerateStylizedBoard(int cardCount)
    {
        boardGenerator.ResetBoard();
        boardGenerator.CheckClones();
        boardGenerator.cardNumber = cardCount;
    }
}
