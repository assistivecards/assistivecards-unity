using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressCardsMatchDetection : MonoBehaviour
{
    [SerializeField] PressCardsBoardGenerator board;
    [SerializeField] PressCardsCounterSpawner[] spawners;
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

    public void CheckCount(int counter, GameObject currentGameObject)
    {
        if (board.pressCount == counter)
        {
            // Debug.Log("LEVEL COMPLETED!");
            cardParent = currentGameObject;
            correctMatches++;
            gameAPI.AddSessionExp();
            UIController.backButton.GetComponent<Button>().interactable = false;
            gameAPI.PlaySFX("Success");

            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].enabled = false;
            }

            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.3f);

            if (correctMatches == 5)
            {
                gameAPI.AddExp(gameAPI.sessionExp);
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
