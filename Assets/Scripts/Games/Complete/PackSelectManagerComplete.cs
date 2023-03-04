using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackSelectManagerComplete : MonoBehaviour
{
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
}
