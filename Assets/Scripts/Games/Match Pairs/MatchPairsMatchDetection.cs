using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchPairsMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private GameAPI gameAPI;
    public bool isMatched = false;
    private Transform matchedTransform;
    private BoxCollider2D matchedCollider;
    [SerializeField] GameObject tempParentPrefab;
    private GameObject tempParent;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            string otherName = other.transform.GetChild(1).name;
            string draggedName = transform.GetChild(1).name;

            if (otherName.Substring(0, otherName.Length - 1) == draggedName.Substring(0, draggedName.Length - 1))
            {
                matchedTransform = other.transform;
                isMatched = true;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piece"))
        {
            string otherName = other.transform.GetChild(1).name;
            string draggedName = transform.GetChild(1).name;

            if (otherName.Substring(0, otherName.Length - 1) == draggedName.Substring(0, draggedName.Length - 1))
            {
                isMatched = false;
            }

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            Debug.Log("Correct Match!");
            var matchedBoxColliders = matchedTransform.gameObject.GetComponents<BoxCollider2D>();
            foreach (var collider in matchedBoxColliders)
            {
                if (collider.size.x == 75)
                    collider.isTrigger = true;
                if (collider.size.x == 150)
                    matchedCollider = collider;
            }
            var draggedBoxColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (var collider in draggedBoxColliders)
            {
                if (collider.size.x == 75)
                    collider.isTrigger = true;
            }
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<MatchPairsDraggablePiece>().enabled = false;
            matchedTransform.GetComponent<MatchPairsDraggablePiece>().enabled = false;

            LeanTween.rotate(matchedTransform.gameObject, Vector3.zero, .25f);
            LeanTween.rotate(gameObject, Vector3.zero, .25f);
            Invoke("SnapIntoPlace", .3f);
            Invoke("PlayScaleAnimation", .6f);
        }

        else
        {
            Debug.Log("Wrong Match!");
            LeanTween.move(gameObject, transform.parent.position, .35f);
        }
    }

    public void SnapIntoPlace()
    {
        if (matchedTransform.GetChild(1).name.Contains("0"))
            LeanTween.move(matchedTransform.gameObject, new Vector3(matchedCollider.bounds.center.x - matchedCollider.bounds.extents.x / 2, matchedCollider.bounds.center.y, matchedCollider.bounds.center.z), 0.25f);
        else if (matchedTransform.GetChild(1).name.Contains("1"))
            LeanTween.move(matchedTransform.gameObject, new Vector3(matchedCollider.bounds.center.x + matchedCollider.bounds.extents.x / 2, matchedCollider.bounds.center.y, matchedCollider.bounds.center.z), 0.25f);
        if (transform.GetChild(1).name.Contains("0"))
            LeanTween.move(gameObject, new Vector3(matchedCollider.bounds.center.x - matchedCollider.bounds.extents.x / 2, matchedCollider.bounds.center.y, matchedCollider.bounds.center.z), 0.25f);
        else if (transform.GetChild(1).name.Contains("1"))
            LeanTween.move(gameObject, new Vector3(matchedCollider.bounds.center.x + matchedCollider.bounds.extents.x / 2, matchedCollider.bounds.center.y, matchedCollider.bounds.center.z), 0.25f);
    }

    public void PlayScaleAnimation()
    {
        tempParent = Instantiate(tempParentPrefab, matchedCollider.bounds.center, Quaternion.identity);
        tempParent.transform.SetParent(GameObject.Find("GamePanel").transform);
        matchedTransform.SetParent(tempParent.transform);
        transform.SetParent(tempParent.transform);
        LeanTween.scale(tempParent, tempParent.transform.localScale * 1.25f, .25f);
        Invoke("ScaleImageDown", .75f);
    }

    public void ScaleImageDown()
    {
        LeanTween.scale(tempParent, Vector3.zero, .25f);
    }
}
