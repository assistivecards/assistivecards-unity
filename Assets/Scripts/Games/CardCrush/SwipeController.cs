using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private BoardController boardController;
    public List<GameObject> selectedElements = new List<GameObject>();

    private Vector3 firstElementPosition;
    private int firstElementXValue;
    private int firstElementYValue;

    private Vector3 secondElementPosition;
    private int secondElementXValue;
    private int secondElementYValue;

    public void SelectElement(GameObject _cardElement)
   {
        if(selectedElements.Count < 2 && !selectedElements.Contains(_cardElement))
        {
            _cardElement.GetComponent<Image>().color = new Color32(255,202,194,255);
            selectedElements.Add(_cardElement);
        }
   }

   public void SwipeElements()
   {
        if(selectedElements.Count > 1)
        {
            if(selectedElements[1].GetComponent<CardTileInformation>().neighbours.Contains(selectedElements[0]))
            {
                firstElementPosition = selectedElements[0].transform.position;
                firstElementXValue = selectedElements[0].GetComponent<CardTileInformation>().xValue;
                firstElementYValue = selectedElements[0].GetComponent<CardTileInformation>().yValue;

                secondElementPosition = selectedElements[1].transform.position;
                secondElementXValue = selectedElements[1].GetComponent<CardTileInformation>().xValue;
                secondElementYValue = selectedElements[1].GetComponent<CardTileInformation>().yValue;

                LeanTween.move(selectedElements[0], secondElementPosition, 0.25f);
                selectedElements[0].GetComponent<CardTileInformation>().xValue = secondElementXValue;
                selectedElements[0].GetComponent<CardTileInformation>().yValue = secondElementYValue;

                LeanTween.move(selectedElements[1], firstElementPosition, 0.25f);
                selectedElements[1].GetComponent<CardTileInformation>().xValue = firstElementXValue;
                selectedElements[1].GetComponent<CardTileInformation>().yValue = firstElementYValue;


                selectedElements[0].GetComponent<Image>().color = new Color32(255,255,255,255);
                selectedElements[1].GetComponent<Image>().color = new Color32(255,255,255,255);

                selectedElements[0].GetComponent<CardTileInformation>().CheckMatch();
                selectedElements[1].GetComponent<CardTileInformation>().CheckMatch();

                selectedElements.Clear();

                DetectNeightboursOnBoard();

            }
            else if(!selectedElements[1].GetComponent<CardTileInformation>().neighbours.Contains(selectedElements[0]))
            {
                selectedElements.Clear();
            }
        }
   } 

   private void DetectNeightboursOnBoard()
   {
        foreach(var card in boardController.cards)
        {
            card.GetComponent<CardTileInformation>().ResetNeighbours();
            card.GetComponent<CardTileInformation>().DetectNeightbours();
        }
   }
}