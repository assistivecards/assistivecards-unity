using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetChooseTutorial : MonoBehaviour
{
    public void SetPosition(Transform tutorialPosition) 
    {
        LeanTween.move(this.gameObject, tutorialPosition.position, 0);
    }
}
