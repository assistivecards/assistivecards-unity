using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressCardsMatchDetection : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    [SerializeField] PressCardsCounterSpawner spawner;
    public int correctMatches;
    [SerializeField] GameObject cardParent;

    public void CheckCount()
    {
        if (board.pressCount == spawner.counter)
        {
            // Debug.Log("LEVEL COMPLETED!");
            correctMatches++;
            spawner.enabled = false;
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);
            board.Invoke("GenerateRandomBoardAsync", 1.3f);
        }
    }

}
