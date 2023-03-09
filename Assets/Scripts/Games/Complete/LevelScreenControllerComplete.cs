using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreenControllerComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;
    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.5f, 0.5f);
    }

    public void LevelScreenClose()
    {
        LeanTween.scale(this.gameObject, Vector3.zero, 0.25f).setOnComplete(Close);
    }

    private void Close()
    {
        this.gameObject.SetActive(false);
        boardCreatorComplete.levelEnded = false;
        boardCreatorComplete.isBoardCreated = false;
    }
}
