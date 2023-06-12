using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFishingTutorial : MonoBehaviour
{
    [SerializeField] private GameObject rod;

    private void Update() 
    {
        this.transform.position = rod.transform.position;
    }
}
