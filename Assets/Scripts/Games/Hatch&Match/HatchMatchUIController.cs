using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchMatchUIController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;
    [SerializeField] private GameObject levelChange;
    private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        levelChangeScreenHatchMatch = levelChange.GetComponent<LevelChangeScreenHatchMatch>();
    }

    private void FixedUpdate() 
    {
        // if(boardCreatorHatchMatch.levelCount > 5)
        // {
        //     levelChange.SetActive(true);
        //     LeanTween.scale(levelChange, Vector3.one * 0.6f, 0.5f);
        // }
    }

}
