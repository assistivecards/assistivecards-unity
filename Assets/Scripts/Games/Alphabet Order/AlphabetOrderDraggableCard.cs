using UnityEngine;
using UnityEngine.EventSystems;

public class AlphabetOrderDraggableCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameAPI gameAPI;
    public string parentName;
    private AlphabetOrderBoardGenerator board;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<AlphabetOrderBoardGenerator>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = transform.position + new Vector3(eventData.delta.x, eventData.delta.y, 0);
        transform.SetParent(GameObject.Find("GamePanel").transform);
        transform.SetAsLastSibling();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameAPI.VibrateWeak();
        gameAPI.PlaySFX("Pickup");
        parentName = transform.parent.name;

        for (int i = 0; i < board.cardParents.Length; i++)
        {
            board.cardParents[i].GetComponent<AlphabetOrderDraggableCard>().enabled = false;
        }
        gameObject.GetComponent<AlphabetOrderDraggableCard>().enabled = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        for (int i = 0; i < board.cardParents.Length; i++)
        {
            if (!board.cardParents[i].GetComponent<AlphabetOrderMatchDetection>().isMatched)
            {
                board.cardParents[i].GetComponent<AlphabetOrderDraggableCard>().enabled = true;
            }
        }
    }

}
