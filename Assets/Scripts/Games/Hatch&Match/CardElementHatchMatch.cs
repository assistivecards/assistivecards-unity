using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardElementHatchMatch : MonoBehaviour
{
    private EggController eggController;


    private void Start() 
    {
        eggController = FindObjectOfType<EggController>();
    }
}
