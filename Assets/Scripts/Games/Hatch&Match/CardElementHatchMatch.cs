using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    GameAPI gameAPI;
    private EggController eggController;
    private BoardCreatorHatchMatch boardCreatorHatchMatch;
    public bool match;
    private GameObject levelChange;
    private LevelChangeScreenHatchMatch levelChangeScreenHatchMatch;

    public string cardName;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start() 
    {
        eggController = FindObjectOfType<EggController>();
        boardCreatorHatchMatch = GetComponentInParent<BoardCreatorHatchMatch>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!match)
            this.transform.position = eventData.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.name == this.gameObject.name)
        {
            match = true;
            gameAPI.Speak(cardName);
            LeanTween.move(this.gameObject, other.transform.position, 0.75f).setOnComplete(LevelEnd);
        }
    }

    private void LevelEnd()
    {
        boardCreatorHatchMatch.levelEnd = true;

        if(boardCreatorHatchMatch.levelCount < 6)
        {
            boardCreatorHatchMatch.NewLevel();
        }
        else
        {
            boardCreatorHatchMatch.ActivateLevelChange();
            boardCreatorHatchMatch.ResetBoard();
        }
    }
}
