using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCardChain : MonoBehaviour
{
    [SerializeField] private UIControllerCardChain uıController;


    private void OnEnable() 
    {
        if(!uıController.firstTime)
       {
            this.GetComponent<Tutorial>().tutorialPosition = uıController.cardPosition.transform;
            uıController.TutorialLoopPosition1();
       } 
    }
}
