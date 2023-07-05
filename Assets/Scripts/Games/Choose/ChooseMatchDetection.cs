using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseMatchDetection : MonoBehaviour, IPointerClickHandler
{
    private ChooseBoardGenerator board;
    public bool isClicked = false;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<ChooseBoardGenerator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClicked)
        {
            if (transform.GetChild(0).GetComponent<Image>().sprite.texture.name == board.correctCardSlug)
            {
                Debug.Log("CORRECT CARD");
            }
            else
            {
                Debug.Log("WRONG CARD");
            }

            isClicked = true;
        }
    }

}
