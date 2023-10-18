using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawnerComplete : MonoBehaviour
{
    [SerializeField] private BoardGeneratorComplete boardGenerator;
    public bool hasChild;

    public void CheckChild()
    {      
        if(transform.childCount == 0)
        {
            hasChild = false;
            boardGenerator.FillCardSlot();
        }
        else if(transform.childCount > 0)
        {
            hasChild = true;
        }
    }
}
