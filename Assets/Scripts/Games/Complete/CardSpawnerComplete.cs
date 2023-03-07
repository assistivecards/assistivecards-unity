using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawnerComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;
    private bool oneTime = true;


    private void Update() 
    {
        if(oneTime)
        {
            CardSpawner();
        }
    }

    public void CardSpawner()
    {      
        if(boardCreatorComplete.isBoardCreated)    
        {
            if(GetComponentInChildren<CardElementComplete>() != null)
            {
                if(GetComponentInChildren<CardElementComplete>().matched)
                {
                    boardCreatorComplete.GenerateCardFirst(boardCreatorComplete.packSlug, boardCreatorComplete.randomValueList[Random.Range(0,12)]);
                    oneTime = false;
                }
            }
        }
    }
}
