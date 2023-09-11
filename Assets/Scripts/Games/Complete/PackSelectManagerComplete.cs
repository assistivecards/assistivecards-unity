using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackSelectManagerComplete : MonoBehaviour
{
    [SerializeField] private UIControllerComplete uıController;
    [SerializeField] private PackSelectionScreenUIController packSelectionScreenUIController;
    [SerializeField] private PackSelectionPanel packSelectionPanel;
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;
    private string selectedPack;

    public void OnPackSelect()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            selectedPack = packSelectionPanel.selectedPackElement.name;
        }
    }

    public async void GenerateStylizedBoard()
    {
        if(packSelectionScreenUIController.canGenerate)
        {
            await boardCreatorComplete.CacheCards(selectedPack);
        }  
    }

    public async void GenerateStylizedBoardContinue()
    {
        boardCreatorComplete.CacheCards(selectedPack);
        //await boardCreatorComplete.CacheCards(selectedPack); 
    }

    public void ResetScroll()
    {
        this.transform.GetChild(0).GetChild(0).GetChild(0).transform.localPosition = Vector3.zero;
    }
}
