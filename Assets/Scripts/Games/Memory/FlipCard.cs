using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipCard : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float x,y,z;
    private Transform cardBack;
    public bool isCardBackActive = false;
    private int timer;
    public bool touched = false;

    private void Awake() 
    {
        cardBack = this.transform.GetChild(1);
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartFlip();
    }

    private void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }


    private void Flip()
    {
        if(isCardBackActive == true)
        {
            cardBack.gameObject.SetActive(false);
            isCardBackActive = false;
        }
        else
        {
            cardBack.gameObject.SetActive(true);
            isCardBackActive = true;
        }
    }

    IEnumerator CalculateFlip()
    {
        for(int i = 0; i <180; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }
}
