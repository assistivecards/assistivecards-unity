using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FindCardFlipCard : MonoBehaviour, IPointerClickHandler
{
    private FindCardMatchDetection matchDetector;
    private GameAPI gameAPI;
    public bool isFlipped = false;
    public bool firstFlip = false;
    public bool isClicked;

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
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            LeanTween.rotateY(gameObject, -180, .75f);
            // .setOnComplete(() => matchDetector.CheckCard(transform))
            Invoke("TriggerCheckCard", .75f);
            gameAPI.PlaySFX("FlipCard");
            isFlipped = true;
        }
        else
        {
            if (Input.touchCount == 1)
            {
                if (transform.rotation.eulerAngles.y < 2)
                {
                    LeanTween.rotateY(gameObject, -180, .75f);
                    // .setOnComplete(() => matchDetector.CheckCard(transform))
                    Invoke("TriggerCheckCard", .75f);
                    gameAPI.PlaySFX("FlipCard");
                    isFlipped = true;
                }
            }
        }
    }

    public void FlipBack()
    {
        LeanTween.rotateY(gameObject, 0, .75f);
    }

    public void TriggerCheckCard()
    {
        if(firstFlip)
        {
            matchDetector.CheckCard(transform);
            isClicked = true;
        }
    }

}
