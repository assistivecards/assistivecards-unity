using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject transitionScreen;
    [SerializeField] private GameObject levelChangeScreen;
    [SerializeField] private GameObject difficultySelectionScreen;
    [SerializeField] private TransitionScreenManager transitionScreenManager;
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
        await boardGenerator.CacheCards(selectedPack);
        transitionScreenManager.IncrementProgress(1);
    }

    public async void GenerateStylizedBoard(int cardCount)
    {
        boardGenerator.ResetBoard();
        boardGenerator.cardNumber = cardCount;
        await boardGenerator.CacheCards(selectedPack);
        transitionScreenManager.IncrementProgress(1);
    }
}
