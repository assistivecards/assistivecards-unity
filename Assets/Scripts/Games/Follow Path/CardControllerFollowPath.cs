using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerFollowPath : MonoBehaviour
{
    public bool isCorrect;
    public bool isAllCorrectSelected;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Touch")
        {
            if(isAllCorrectSelected && isCorrect)
            {
                Debug.Log("Level End");
            }
            else
            {
                Debug.Log(this.name);
            }
        }
    }
}
