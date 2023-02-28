using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenHatchMatch : MonoBehaviour
{
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;
    [SerializeField] private GameObject packageSelectScreen;
    public bool isOnpackSelect = false;

    public void LevelScreenTween()
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.5f);
        isOnpackSelect = true;
    }

    public void DestroySelf()
    {
        isOnpackSelect = false;
        this.gameObject.SetActive(false);
        boardCreatorHatchMatch.levelCount = 0;
    }
}
