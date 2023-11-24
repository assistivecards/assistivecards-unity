using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardControllerFollowPath : MonoBehaviour
{
    GameAPI gameAPI;
    public BoardGeneratorFollowPath boardGenerator;
    public DetectTouchFollowPath detectTouch;
    public bool isCorrect;
    public bool isAllCorrectSelected;
    public bool isReferenceCard;
    public bool isMatch = false;

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorFollowPath>();
        detectTouch = GameObject.Find("GamePanel").GetComponent<DetectTouchFollowPath>();
    }

    public void MoveToBeginning()
    {
        if(!isMatch)
        {
            LeanTween.move(this.gameObject, boardGenerator.stablePosition.transform.position, 0.5f);
            boardGenerator.gameAPI.RemoveSessionExp();
            boardGenerator.ResetSelectedPathColor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isReferenceCard && other.tag == "Correct")
        {
            boardGenerator.CheckPath(this.gameObject);
            if(isAllCorrectSelected)
            {
                isMatch = true;
                LeanTween.move(this.gameObject, other.transform.position, 0.2f);
                boardGenerator.gameAPI.PlayConfettiParticle(this.transform.position);   
                boardGenerator.gameAPI.PlaySFX("Success");
                boardGenerator.Invoke("ClearBoard", 1.5f);
                boardGenerator.gameAPI.AddSessionExp();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Touch" && isReferenceCard)
        {
            if(!isMatch) 
            { 
                detectTouch.referenceCard = this.gameObject;
            }
        }
    }
}
