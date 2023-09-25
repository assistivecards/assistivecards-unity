using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    private BoardGeneration board;
    private DrawManager drawManager;
    public int collisionCount;
    private GameObject matchedCard;
    private Color32 success = new Color32(27, 151, 56, 255);
    private GameAPI gameAPI;
    private CircleUIController UIController;
    private GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        drawManager = GameObject.Find("DrawManager").GetComponent<DrawManager>();
        board = GameObject.Find("GamePanel").GetComponent<BoardGeneration>();
        UIController = GameObject.Find("GamePanel").GetComponent<CircleUIController>();
        backButton = GameObject.Find("Back");
    }

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        matchedCard = other.gameObject;
        var polygonCollider = drawManager.currentLine.GetComponentInChildren<PolygonCollider2D>();

        if ((other.gameObject.tag == "CorrectCard") && (collisionCount == 1) && drawManager.isValid && (polygonCollider.bounds.extents.x >= 1 && polygonCollider.bounds.extents.y >= 1))
        {
            Invoke("CheckIfMatchIsCorrect", 0.05f);
        }
        else
        {
            //Wrong Match
            gameAPI.RemoveSessionExp();
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
            gameAPI.AddSessionExp();
            backButton.GetComponent<Button>().interactable = false;
            Debug.Log(UIController.correctMatches);
            drawManager.gameObject.SetActive(false);
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(matchedCard.transform.position);
            LeanTween.color(transform.parent.GetComponent<LineRenderer>().gameObject, success, .25f);
            Invoke("FadeOutAndDestroyLine", 0.45f);
            board.Invoke("ReadCard", 0.5f);
            Invoke("PlayCorrectMatchAnimation", 0.5f);
            board.Invoke("ScaleImagesDown", 1.25f);
            board.Invoke("ClearBoard", 1.5f);
            if (UIController.correctMatches == 10)
            {
                // OpenCheckPointPanel();
                gameAPI.AddExp(gameAPI.sessionExp);
                UIController.Invoke("OpenCheckPointPanel", 1.25f);
            }
            else
                board.Invoke("GenerateRandomBoardAsync", 1.5f);

        }
    }

    public void PlayCorrectMatchAnimation()
    {
        LeanTween.scale(matchedCard, Vector3.one * 1.25f, .25f);
    }
}
