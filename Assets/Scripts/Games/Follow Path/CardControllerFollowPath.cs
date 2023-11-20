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

    private void OnEnable() 
    {
        boardGenerator = GameObject.Find("GamePanel").GetComponent<BoardGeneratorFollowPath>();
        detectTouch = GameObject.Find("GamePanel").GetComponent<DetectTouchFollowPath>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch" && !isReferenceCard)
        {
            boardGenerator.CheckPath();
            if(isAllCorrectSelected && isCorrect)
            {
                boardGenerator.gameAPI.PlayConfettiParticle(this.transform.position);   
                boardGenerator.Invoke("ClearBoard", 1.5f);
            }
            else
            {
                Debug.Log(this.name);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Touch" && isReferenceCard)
        {
            detectTouch.referenceCard = this.gameObject;
        }
    }
}
