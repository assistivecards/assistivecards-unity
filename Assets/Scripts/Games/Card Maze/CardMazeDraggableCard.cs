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

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
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

            if (Input.GetTouch(0).phase == TouchPhase.Moved && isValid)
            {

                var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                newPosition = new Vector3(wp.x, wp.y, transform.position.z);

                GetComponent<Rigidbody2D>().MovePosition(newPosition);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended && isValid)
            {
                isValid = false;
            }

        }
    }
}
