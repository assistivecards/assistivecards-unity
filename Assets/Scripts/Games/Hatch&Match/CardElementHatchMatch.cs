using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardElementHatchMatch : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    GameAPI gameAPI;
    private EggController eggController;
    private BoardCreatorHatchMatch boardCreatorHatchMatch;
    public bool match;

    public string cardName;
    private Vector3 startPosition;

    private void Awake() 
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
        startPosition = transform.position;
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
            gameAPI.PlaySFX("Success");
            gameAPI.PlayConfettiParticle(this.transform.position);
            Invoke("SpeakCardName", 0.5f);
            match = true;
            gameAPI.AddSessionExp();
            LeanTween.move(this.gameObject, other.transform.position, 0.75f).setOnComplete(LevelEnd);
        }
        else if(other.gameObject.name != "Egg" && other.gameObject.name != this.gameObject.name)
        {
            other.GetComponent<Image>().CrossFadeAlpha(0, 1.3f, false);

            if(other.transform.childCount > 0)
            {
                other.transform.GetChild(0).gameObject.GetComponent<RawImage>().CrossFadeAlpha(0, 1.3f, false);
                gameAPI.RemoveSessionExp();
                Invoke("MoveToBegging", 0.15f);
            }
        }
    }

    private void MoveToBegging()
    {
        LeanTween.move(this.gameObject, startPosition, 1.25f);
    }

    private void SpeakCardName()
    {

        gameAPI.Speak(cardName);
    }

    private void LevelEnd()
    {
        boardCreatorHatchMatch.levelEnd = true;

        if(boardCreatorHatchMatch.levelCount < 4)
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
