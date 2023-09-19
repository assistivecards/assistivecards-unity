using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FindCardFlipCard : MonoBehaviour, IPointerClickHandler
{
    private FindCardMatchDetection matchDetector;
    private GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        matchDetector = GameObject.Find("GamePanel").GetComponent<FindCardMatchDetection>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            if (transform.rotation.eulerAngles.y < 2)
            {
                LeanTween.rotateY(gameObject, -180, .75f);
                // .setOnComplete(() => matchDetector.CheckCard(transform))
                Invoke("TriggerCheckCard", .75f);
                gameAPI.PlaySFX("FlipCard");
            }
        }


    }

    public void FlipBack()
    {
        LeanTween.rotateY(gameObject, 0, .75f);
    }

    public void TriggerCheckCard()
    {
        matchDetector.CheckCard(transform);
    }

}
