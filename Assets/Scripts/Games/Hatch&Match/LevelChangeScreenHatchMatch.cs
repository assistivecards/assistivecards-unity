using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenHatchMatch : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;
    [SerializeField] private GameObject packageSelectScreen;
    public bool isOnpackSelect = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void LevelScreenTween()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.5f);
        isOnpackSelect = true;
    }

    public void DestroySelf()
    {
        isOnpackSelect = false;
        gameAPI.ResetSessionExp();
        this.gameObject.SetActive(false);
        boardCreatorHatchMatch.levelCount = 0;
    }
}
