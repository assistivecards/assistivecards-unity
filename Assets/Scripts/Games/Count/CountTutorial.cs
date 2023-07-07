using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTutorial : MonoBehaviour
{
    [SerializeField] private CountGenerateBoard boardGenerator;

    public void SetTutorialPosition() 
    {
        LeanTween.move(this.gameObject, boardGenerator.correctButton.transform.position, 0f);
    }
}
