using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressCardsMatchDetection : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    [SerializeField] PressCardsCounterSpawner spawner;
    public int correctMatches;
    [SerializeField] GameObject cardParent;
    private PressCardsUIController UIController;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

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
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");
            spawner.enabled = false;
            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (correctMatches == 5)
            {
                UIController.Invoke("OpenCheckPointPanel", 1.3f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
        }
    }

    public void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(cardParent, Vector3.one * 1.15f, .25f);
    }

}
