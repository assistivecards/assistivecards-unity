using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseMatchDetection : MonoBehaviour, IPointerClickHandler
{
    private ChooseBoardGenerator board;
    public bool isClicked = false;
    private ChooseUIController UIController;

    private void Start()
    {
        board = GameObject.Find("GamePanel").GetComponent<ChooseBoardGenerator>();
        UIController = GameObject.Find("GamePanel").GetComponent<ChooseUIController>();
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

                UIController.correctMatches++;
                UIController.backButton.GetComponent<Button>().interactable = false;
                LeanTween.scale(gameObject, Vector3.one * 1.15f, .25f);
                board.Invoke("ScaleImagesDown", 1f);
                board.Invoke("ClearBoard", 1.30f);

                if (UIController.correctMatches == UIController.checkpointFrequency)
                {
                    UIController.Invoke("OpenCheckPointPanel", 1.3f);
                }
                else
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
