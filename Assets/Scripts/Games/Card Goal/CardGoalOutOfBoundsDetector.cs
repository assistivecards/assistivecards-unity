using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGoalOutOfBoundsDetector : MonoBehaviour
{
    Collider2D collidedCard;
    [SerializeField]
    Transform goalPost;
    private CardGoalBoardGenerator board;

    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        RectTransform rect = GetComponent<RectTransform>();
        collider.size = new Vector2(rect.rect.width, rect.rect.height);
        board = GameObject.Find("GamePanel").GetComponent<CardGoalBoardGenerator>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Out Of Bounds!!!");
        collidedCard = other;
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
            LeanTween.alpha(collidedCard.gameObject, 1, .001f);
            collidedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            collidedCard.transform.position = collidedCard.transform.parent.position;
            rb.freezeRotation = false;
            for (int i = 0; i < board.cardParents.Length; i++)
            {
                board.cardParents[i].GetComponent<CardGoalFlickManager>().canThrow = true;
                board.cardParents[i].GetComponent<BoxCollider2D>().isTrigger = true;
            }
            collidedCard.GetComponent<CardGoalFlickManager>().isValid = false;
            LeanTween.scale(collidedCard.gameObject, Vector3.one * 12, .2f);
        }

    }
}
