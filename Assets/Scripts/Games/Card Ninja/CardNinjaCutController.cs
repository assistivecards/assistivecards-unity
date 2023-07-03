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
    public int levelEndedCount;

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
        if(throwedCount == 20 && cutCount < 10)
        {
            if(levelEndedCount < 2)
            {
                LevelRefresh();
                boardGenerator.LevelEndCardScale();
                levelEndedCount++;
            }
            else if(levelEndedCount >= 2)
            {
                boardGenerator.LevelEndCardScale();
                Invoke("CallNewLevel", 2f);
            } 
        }
        if(cutCount >= 10)
        {
            boardGenerator.LevelEndCardScale();
            Invoke("CallNewLevel", 2f);
        }
    }

    private void Update() 
    {
        Vector2 trailPos = Camera.main.ScreenToWorldPoint(touchPosition);
        cutEffect.transform.position = trailPos;
    }

    private void LevelRefresh()
    {
        cutEffect.SetActive(false);
        throwedCount = 0;
        uıController.cutText.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = cutController.cutCount + " / 10";
        uıController.ReloadLevel();
        boardGenerator.GeneratedBoardAsync();
    }

    public void CallNewLevel()
    {
        ResetLevel();
        uıController.LevelEnd();
    }

    public void ResetLevel()
    {
        levelEndedCount = 0;
        cutCount = 0;
        throwedCount = 0;
        uıController.cutText.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = cutController.cutCount + " / 10";
    }
}
