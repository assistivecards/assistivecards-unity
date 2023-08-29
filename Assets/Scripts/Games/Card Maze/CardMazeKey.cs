using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMazeKey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LeanTween.scale(gameObject, Vector3.zero, 0.2f);
            Debug.Log("Key is grabbed");
        }
    }
}
