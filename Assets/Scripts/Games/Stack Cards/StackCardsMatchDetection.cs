using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackCardsMatchDetection : MonoBehaviour, IPointerUpHandler
{
    private GameAPI gameAPI;
    public bool isMatched = false;
    private Transform matchedSlotTransform;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1 && other.tag == "FixedCard")
        {
            matchedSlotTransform = other.transform;
            isMatched = true;
            Debug.Log("Correct Match! ENTER");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.GetChild(0).GetComponent<Image>().sprite == transform.GetChild(0).GetComponent<Image>().sprite && other.transform.childCount == 1 && other.tag == "FixedCard")
        {
            isMatched = false;
            Debug.Log("Correct Match! EXIT");
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMatched)
        {
            gameObject.GetComponent<StackCardsDraggableCards>().enabled = false;
            transform.SetParent(matchedSlotTransform);
            LeanTween.moveLocal(gameObject, new Vector3(-20, -20, 0), 0.25f);
            LeanTween.rotate(gameObject, Vector3.zero, .25f);
            gameObject.tag = "FixedCard";
        }
    }

}
