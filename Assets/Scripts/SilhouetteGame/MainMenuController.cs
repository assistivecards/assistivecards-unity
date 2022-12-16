using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Board board;
    [SerializeField] PackSelectionPanel packSelectionPanel;

    public async void OnPackSelect()
    {
        board.packSlug = packSelectionPanel.selectedPackElement.name;
        await board.CacheCards(board.packSlug);
        await board.GenerateRandomBoardAsync();
    }
}
