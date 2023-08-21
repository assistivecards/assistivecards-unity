using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawnerComplete : MonoBehaviour
{
    [SerializeField] private BoardCreatorComplete boardCreatorComplete;
    public bool hasChild;

    public void CheckChild()
    {      
        if(transform.childCount == 0)
        {
            hasChild = false;
            boardCreatorComplete.FillCardSlot();
        }
        else if(transform.childCount > 0)
        {
            hasChild = true;
        }
    }
}
