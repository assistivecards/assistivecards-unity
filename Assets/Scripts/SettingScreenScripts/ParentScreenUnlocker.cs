using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ParentScreenUnlocker : MonoBehaviour, IPointerUpHandler
{
    public UnityEvent parentLockScreenUnlocked;
    private bool isOnLock = false;
    private Vector2 firstPosition;

    private void Start() 
    {
        firstPosition = this.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "ParentScreenLock")
        {
            isOnLock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "ParentScreenLock")
        {
            isOnLock = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(isOnLock)
        {
            parentLockScreenUnlocked.Invoke();

            this.transform.position = firstPosition;
        }
        else
        {
            this.transform.position = firstPosition;
        }

    }

}
