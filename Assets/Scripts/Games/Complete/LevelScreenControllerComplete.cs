using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreenControllerComplete : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.5f);
    }

    public void LevelScreenClose()
    {
        gameAPI.ResetSessionExp();
        LeanTween.scale(this.gameObject, Vector3.zero, 0.25f).setOnComplete(Close);
    }

    private void Close()
    {
        Invoke("SetActiveFalse", 0.75f);
        boardCreatorComplete.levelEnded = false;
        boardCreatorComplete.isBoardCreated = false;
    }

    private void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
