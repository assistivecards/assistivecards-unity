using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScreenHatchMatch : MonoBehaviour
{
    [SerializeField] private BoardCreatorHatchMatch boardCreatorHatchMatch;
    [SerializeField] private GameObject packageSelectScreen;
    private void OnEnable() 
    {
        LeanTween.scale(this.gameObject, Vector3.one * 0.6f, 0.15f);
    }

    public void ContinueClick()
    {
        boardCreatorHatchMatch.levelCount = 0;
        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);
    }

    public void NewPackClick()
    {
        packageSelectScreen.SetActive(true);
        LeanTween.scale(this.gameObject, Vector3.zero, 0.15f);
    }
}
