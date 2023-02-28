using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchMatchUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;

    [SerializeField] private GameObject levelChange;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Update() 
    {
        if(boardCreatorHatchMatch.levelCount > 5)
        {
            boardCreatorHatchMatch.ResetBoard();
            LeanTween.scale(levelChange, Vector3.one * 0.6f, 0.15f);
            levelChange.SetActive(true);
        }
    }

}
