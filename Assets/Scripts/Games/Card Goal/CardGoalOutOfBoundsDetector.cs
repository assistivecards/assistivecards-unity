using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGoalOutOfBoundsDetector : MonoBehaviour
{
    [SerializeField] Collider2D collidedCard;
    [SerializeField]
    Transform goalPost;
    private CardGoalBoardGenerator board;
    private CardGoalUIController UIController;

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
        board = GameObject.Find("GamePanel").GetComponent<CardGoalBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<CardGoalUIController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out Of Bounds!!!");
        collidedCard = other;
        UIController.backButton.GetComponent<Button>().interactable = false;
        LeanTween.alpha(collidedCard.gameObject, 0, .2f);
        Invoke("ResetCardPosition", .25f);

    }

    void ResetCardPosition()
    {
        if (goalPost.localScale == Vector3.one * .75f)
        {
            Rigidbody2D rb = collidedCard.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
            collidedCard.transform.localScale = Vector3.zero;
            // LeanTween.alpha(collidedCard.gameObject, 1, .001f);
            collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            collidedCard.transform.position = collidedCard.transform.parent.position;
            collidedCard.GetComponent<SpriteRenderer>().sortingOrder = 2;
            collidedCard.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
            rb.freezeRotation = false;
            for (int i = 0; i < board.cardParents.Length; i++)
            {
                board.cardParents[i].GetComponent<CardGoalFlickManager>().canThrow = true;
                board.cardParents[i].GetComponent<BoxCollider2D>().isTrigger = true;
                LeanTween.alpha(board.cardParents[i], 1, .001f);
            }
            collidedCard.GetComponent<CardGoalFlickManager>().isValid = false;
            LeanTween.scale(collidedCard.gameObject, Vector3.one * 12, .2f);
            UIController.backButton.GetComponent<Button>().interactable = true;
        }

    }

    public void InvokeResetAllCardPositions()
    {
        Invoke("ResetAllCardPositions", .25f);
    }

    void ResetAllCardPositions()
    {
        if (goalPost.localScale == Vector3.one * .75f)
        {

            for (int i = 0; i < board.cardParents.Length; i++)
            {
                board.cardParents[i].GetComponent<Rigidbody2D>().isKinematic = true;
                board.cardParents[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                board.cardParents[i].GetComponent<Rigidbody2D>().freezeRotation = true;
                board.cardParents[i].transform.localScale = Vector3.zero;
                // LeanTween.alpha(collidedCard.gameObject, 1, .001f);
                board.cardParents[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                board.cardParents[i].transform.position = board.cardSlots[i].transform.position;
                board.cardParents[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
                board.cardParents[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 3;
                board.cardParents[i].GetComponent<Rigidbody2D>().freezeRotation = false;
                board.cardParents[i].GetComponent<CardGoalFlickManager>().canThrow = true;
                board.cardParents[i].GetComponent<BoxCollider2D>().isTrigger = true;
                LeanTween.alpha(board.cardParents[i], 1, .001f);
                board.cardParents[i].GetComponent<CardGoalFlickManager>().isValid = false;
                LeanTween.scale(board.cardParents[i].gameObject, Vector3.one * 12, .2f);
            }

            UIController.backButton.GetComponent<Button>().interactable = true;
        }
    }
}
