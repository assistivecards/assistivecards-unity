using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutMatchDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CorrectCard")
        {
            Debug.Log("Correct Match!");
        }

        else if (other.tag == "WrongCard")
        {
            Debug.Log("Wrong Match!");
        }
    }
}
