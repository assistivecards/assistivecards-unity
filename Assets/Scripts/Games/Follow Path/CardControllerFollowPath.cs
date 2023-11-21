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
    private BoardGeneratorFollowPath boardGenerator;
    private DetectTouchFollowPath detectTouch;
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
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch" && !isReferenceCard)
        {
            boardGenerator.CheckPath();
            if(isAllCorrectSelected && isCorrect)
            {
                boardGenerator.gameAPI.PlayConfettiParticle(this.transform.position);   
                boardGenerator.gameAPI.PlaySFX("Success");
                boardGenerator.Invoke("ClearBoard", 1.5f);
            }
        }
        if(isReferenceCard && other.tag == "Correct")
        {
            isMatch = true;
            LeanTween.move(this.gameObject, other.transform.position, 0.2f);
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
