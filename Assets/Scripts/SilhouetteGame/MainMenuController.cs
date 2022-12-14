using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Board board;

    public async void PlayButtonClicked()
    {
        board.packSlug = inputField.text;
        await board.GenerateRandomBoardAsync();
    }
}
