using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CardFishingRodController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject rod;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private float speed;
    public bool isPointerDown;


    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    void Update()
    {
        if(point1 != null && point2 != null && !isPointerDown)
        {
            rod.transform.position = Vector3.Lerp(point1.position, point2.position, Mathf.PingPong(Time.time * speed, 1));
            Invoke("ResetSize", 0.5f);
        }
        else if(isPointerDown)
        {
            Resize(Time.time * 0.0025f);
        }
    }

    public void Resize(float resizeAmount)
    {
        if(rod.transform.GetChild(1).transform.localScale.y <= 20)
        {
            rod.transform.GetChild(1).transform.localScale += new Vector3(0, resizeAmount, 0);
            rod.transform.GetChild(1).transform.localPosition += new Vector3(0 , -resizeAmount * 10, 0); 
        }
    }

    public void ResetSize()
    {
        rod.transform.GetChild(1).transform.localScale = new Vector3(rod.transform.GetChild(1).transform.localScale.x, 0, rod.transform.GetChild(1).transform.localScale.z);
        rod.transform.GetChild(1).transform.localPosition = new Vector3(rod.transform.GetChild(1).transform.localPosition.x, -25f, rod.transform.GetChild(1).transform.localPosition.z);
    }
}
