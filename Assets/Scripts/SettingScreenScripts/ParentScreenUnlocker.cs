using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ParentScreenUnlocker : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private TopAppBarController topAppBarController;
    [SerializeField] private GameObject dummyLock;
    [SerializeField] private GameObject parentalGate;
    private bool isOnLock = false;

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
            this.transform.position = dummyLock.transform.position;

            parentalGate.SetActive(false);
            topAppBarController.ChangeTopAppBarType(0);
        }
        else
        {
            this.transform.position = dummyLock.transform.position;
        }

    }
}
