using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CardNinjaCutController : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerUpHandler, IEndDragHandler
{
    GameAPI gameAPI;
    [SerializeField] private CardNinjaUIController uıController;
    [SerializeField] private CardNinjaBoardGenerator boardGenerator;
    [SerializeField] private CardNinjaCutController cutController;
    [SerializeField] private GameObject cutEffect;
    private Vector2 dragStartPosition;
    private Vector2 touchPosition;
    private Vector2 dragDirection;
    public bool isDragging;
    public bool horizontalDrag;
    public bool verticalDrag;
    public int cutCount;
    public int throwedCount;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            cutEffect.SetActive(true);
            cutEffect.GetComponent<TrailRenderer>().enabled = true;
            Vector2 dragEndPosition = eventData.position;
            dragDirection = dragEndPosition - dragStartPosition;

            touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
            if(Mathf.Abs(dragDirection.x) >= Mathf.Abs(dragDirection.y))
            {
                horizontalDrag = true;
                verticalDrag = false;
            }
            else if(Mathf.Abs(dragDirection.x) < Mathf.Abs(dragDirection.y))
            {
                horizontalDrag = false;
                verticalDrag = true;
            }
            else if(Mathf.Abs(dragDirection.x) >= 1000)
            {
                cutEffect.GetComponent<TrailRenderer>().Clear();
                dragDirection = Vector2.zero;
            }
            else if(Mathf.Abs(dragDirection.y) >= 1000)
            {
                cutEffect.GetComponent<TrailRenderer>().Clear();
                dragDirection = Vector2.zero;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                cutEffect.SetActive(true);
                cutEffect.GetComponent<TrailRenderer>().enabled = true;
                Vector2 dragEndPosition = eventData.position;
                dragDirection = dragEndPosition - dragStartPosition;

                touchPosition = new Vector3(eventData.position.x, eventData.position.y, 0);
                if(Mathf.Abs(dragDirection.x) >= Mathf.Abs(dragDirection.y))
                {
                    horizontalDrag = true;
                    verticalDrag = false;
                }
                else if(Mathf.Abs(dragDirection.x) < Mathf.Abs(dragDirection.y))
                {
                    horizontalDrag = false;
                    verticalDrag = true;
                }
                else if(Mathf.Abs(dragDirection.x) >= 1000)
                {
                    cutEffect.GetComponent<TrailRenderer>().Clear();
                    dragDirection = Vector2.zero;
                }
                else if(Mathf.Abs(dragDirection.y) >= 1000)
                {
                    cutEffect.GetComponent<TrailRenderer>().Clear();
                    dragDirection = Vector2.zero;
                }
		    }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        cutEffect.SetActive(false);
        cutEffect.GetComponent<TrailRenderer>().Clear();
        dragDirection = Vector2.zero;
        horizontalDrag = false;
        verticalDrag = false;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        cutEffect.SetActive(false);
        cutEffect.GetComponent<TrailRenderer>().Clear();
        dragDirection = Vector2.zero;
        horizontalDrag = false;
        verticalDrag = false;
    }

    public void LevelEndCheck()
    {
        if(throwedCount >= 10 && cutCount < 5)
        {
            if(boardGenerator.levelCount < boardGenerator.maxLevelCount - 1)
            {
                boardGenerator.LevelEndCardScale();
                boardGenerator.levelCount++;
                ResetLevel();
                Invoke("LevelRefresh", 0.5f);
            }
            else if(boardGenerator.levelCount >= boardGenerator.maxLevelCount - 1)
            {
                boardGenerator.LevelEndCardScale();
                Invoke("CallNewLevel", 2f);
            } 
        }
        else if(throwedCount <= 10 && cutCount >= 5)
        {
            if(boardGenerator.levelCount < boardGenerator.maxLevelCount - 1)
            {
                boardGenerator.LevelEndCardScale();
                boardGenerator.levelCount++;
                ResetLevel();
                Invoke("LevelRefresh", 0.5f);
            }
            else if(boardGenerator.levelCount >= boardGenerator.maxLevelCount - 1)
            {
                boardGenerator.LevelEndCardScale();
                Invoke("CallNewLevel", 2f);
            } 
        }
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        cutEffect.transform.position = trailPos;
    }

    private void LevelRefresh()
    {
        throwedCount = 0;
        cutEffect.SetActive(false);
        uıController.ReloadLevel();
        boardGenerator.GeneratedBoardAsync();
        uıController.cutText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = cutController.cutCount + " / 5";
    }

    public void CallNewLevel()
    {
        ResetLevel();
        uıController.LevelEnd();
        boardGenerator.levelCount = 0;
        boardGenerator.ClearBoard();
    }

    public void ResetLevel()
    {
        cutCount = 0;
        throwedCount = 0;
        uıController.cutText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = cutController.cutCount + " / 5";
    }
}
