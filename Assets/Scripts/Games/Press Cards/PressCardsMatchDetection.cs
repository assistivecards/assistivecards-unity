using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressCardsMatchDetection : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    [SerializeField] PressCardsCounterSpawner spawner;
    public int correctMatches;
    [SerializeField] GameObject cardParent;
    private PressCardsUIController UIController;

    private void Start()
    {
        UIController = GameObject.Find("GamePanel").GetComponent<PressCardsUIController>();
    }

    public void CheckCount()
    {
        if (board.pressCount == spawner.counter)
        {
            // Debug.Log("LEVEL COMPLETED!");
            correctMatches++;
            spawner.enabled = false;
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (correctMatches == 5)
            {
                board.Invoke("ScaleBoxDown", 1f);
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
        }
    }

}
