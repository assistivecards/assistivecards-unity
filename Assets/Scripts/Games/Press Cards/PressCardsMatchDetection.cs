using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressCardsMatchDetection : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    [SerializeField] PressCardsCounterSpawner spawner;

    public void CheckCount()
    {
        if (board.pressCount == spawner.counter)
        {
            Debug.Log("LEVEL COMPLETED!");
        }
    }

}
