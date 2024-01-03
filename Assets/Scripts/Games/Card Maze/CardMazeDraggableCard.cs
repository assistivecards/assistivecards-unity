using UnityEngine;
using UnityEngine.EventSystems;

public class CardMazeDraggableCard : MonoBehaviour
{

    public bool isValid;
    Vector3 newPosition;
    private GameAPI gameAPI;

    void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void OnMouseDrag()
    {
        var wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition = new Vector3(wp.x, wp.y, transform.position.z);

        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
            {
                isValid = true;
                gameAPI.PlaySFX("Pickup");
            }

            else
            {
                Debug.Log("MISS");
            }

        }
    }
}
