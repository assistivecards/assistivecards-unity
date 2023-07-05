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
                for (int i = 0; i < board.cardParents.Length; i++)
                {
                    board.cardParents[i].GetComponent<ChooseMatchDetection>().isClicked = true;
                }

                LeanTween.scale(gameObject, Vector3.one * 1.15f, .25f);
                board.Invoke("ScaleImagesDown", 1f);
                board.Invoke("ClearBoard", 1.30f);
                board.Invoke("GenerateRandomBoardAsync", 1.3f);
            }
            else
            {
                FadeCardParent();
            }

            isClicked = true;
        }
    }

    private void FadeCardParent()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), .5f, .25f);
    }

}
