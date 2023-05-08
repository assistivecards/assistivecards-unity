using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RopeCutTutorial : MonoBehaviour
{
    private Vector3 point1;
    private Vector3 point2;
    public GameObject[] cardPositions;

    private void OnEnable() 
    {
        Invoke("ChangeTransform", 2f);
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Invoke("SetActiveFalse", 0.15f);
    }

    private void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
        LeanTween.scale(this.gameObject, Vector3.zero, 0f);
    }

    void Update()
    {
        if(point1 != null && point2 != null)
        {
            transform.position = Vector3.Lerp(point1, point2, Mathf.PingPong(Time.time, 1));
        }
        if (Input.touchCount > 0)
        {
            Invoke("SetActiveFalse", 0.7f);
        }
    }

    private void ChangeTransform()
    {
        cardPositions = GameObject.FindGameObjectsWithTag("CorrectCard");
        this.transform.position = new Vector3(cardPositions[1].transform.position.x, cardPositions[1].transform.position.y + 2f, cardPositions[1].transform.position.z);
        LeanTween.scale(this.gameObject, Vector3.one * 30f, 0.2f);
        point1 =  new Vector3(cardPositions[1].transform.position.x + 1.5f, cardPositions[1].transform.position.y + 2f, cardPositions[1].transform.position.z);
        point2 =  new Vector3(cardPositions[1].transform.position.x - 1.5f, cardPositions[1].transform.position.y + 2f, cardPositions[1].transform.position.z);
    }
}
