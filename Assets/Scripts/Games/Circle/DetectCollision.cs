using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private BoardGeneration board;
    private DrawManager drawManager;
    public int collisionCount;
    private GameObject matchedCard;
    private Color32 success = new Color32(206, 221, 162, 255);
    private GameAPI gameAPI;
    private CircleUIController UIController;

    // Start is called before the first frame update
    void Start()
    {
        drawManager = GameObject.Find("DrawManager").GetComponent<DrawManager>();
        board = GameObject.Find("GamePanel").GetComponent<BoardGeneration>();
        UIController = GameObject.Find("GamePanel").GetComponent<CircleUIController>();
    }

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        matchedCard = other.gameObject;

        if (other.gameObject.tag == "CorrectCard" && collisionCount == 1 && drawManager.isValid)
        {
            Invoke("CheckIfMatchIsCorrect", 0.05f);
        }
        else
        {
            //Wrong Match
            FadeOutAndDestroyLine();
        }

    }

    public void FadeOutAndDestroyLine()
    {
        LeanTween.alpha(transform.parent.GetComponent<LineRenderer>().gameObject, 0, .25f);
        Destroy(transform.parent.gameObject, 0.25f);
    }

    public void CheckIfMatchIsCorrect()
    {
        if (transform.parent.GetComponent<LineRenderer>().material.color.a == 1)
        {
            //Correct Match!
            UIController.correctMatches++;
            Debug.Log(UIController.correctMatches);
            drawManager.gameObject.SetActive(false);
            gameAPI.PlaySFX("Success");
            LeanTween.color(transform.parent.GetComponent<LineRenderer>().gameObject, success, .25f);
            Invoke("FadeOutAndDestroyLine", 0.25f);
            board.Invoke("ReadCard", 0.25f);
            Invoke("PlayCorrectMatchAnimation", 0.25f);
            board.Invoke("ScaleImagesDown", 1f);
            board.Invoke("ClearBoard", 1.25f);
            if (UIController.correctMatches == 10)
            {
                // OpenCheckPointPanel();
                UIController.Invoke("OpenCheckPointPanel", 1f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.25f);

        }
    }

    public void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(matchedCard, Vector3.one * 1.25f, .25f);
    }
}
