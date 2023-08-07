using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCardsPartMovement : MonoBehaviour
{
    public GameObject previousPart;

    public void MovePart()
    {
        this.transform.position = previousPart.transform.position;
    } 
}
