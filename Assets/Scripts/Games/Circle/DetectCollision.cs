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
    // Start is called before the first frame update
    void Start()
    {
        drawManager = GameObject.Find("DrawManager").GetComponent<DrawManager>();
        board = GameObject.Find("GamePanel").GetComponent<BoardGeneration>();
    }

    // Update is called once per frame
    void Update()
    {

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
            drawManager.gameObject.SetActive(false);
            LeanTween.color(transform.parent.GetComponent<LineRenderer>().gameObject, success, .25f);
            board.Invoke("ScaleImagesDown", 0.25f);
            Invoke("FadeOutAndDestroyLine", 0.25f);
            board.Invoke("ClearBoard", 0.5f);
            board.Invoke("GenerateRandomBoardAsync", 0.5f);
        }
    }
}
