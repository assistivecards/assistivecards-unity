using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetChooseTutorial : MonoBehaviour
{
    [SerializeField] private Transform dummyPosition;

    public void SetPosition(Transform tutorialPosition) 
    {
        if(tutorialPosition != null)
        {
            LeanTween.move(this.gameObject, tutorialPosition.position, 0);
        }
        else
        {
            this.transform.position = dummyPosition.position;
        }
    }
}
