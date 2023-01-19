using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public List<GameObject> selectedElements = new List<GameObject>();

    private Vector3 firstElementPosition;
    private string firstElementName;
    private int firstElementXValue;
    private int firstElementYValue;

    private Vector3 secondElementPosition;
    private string secondElementName;
    private int secondElementXValue;
    private int secondElementYValue;

    public void SelectElement(GameObject _cardElement)
   {
        if(selectedElements.Count < 2 && !selectedElements.Contains(_cardElement))
        {
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
                firstElementName = selectedElements[0].name;
                firstElementXValue = selectedElements[0].GetComponent<CardTileInformation>().xValue;
                firstElementYValue = selectedElements[0].GetComponent<CardTileInformation>().yValue;

                secondElementPosition = selectedElements[1].transform.position;
                secondElementName = selectedElements[1].name;
                secondElementXValue = selectedElements[1].GetComponent<CardTileInformation>().xValue;
                secondElementYValue = selectedElements[1].GetComponent<CardTileInformation>().yValue;

                LeanTween.move(selectedElements[0], secondElementPosition, 0.25f);
                selectedElements[0].GetComponent<CardTileInformation>().xValue = secondElementXValue;
                selectedElements[0].GetComponent<CardTileInformation>().yValue = secondElementYValue;
                selectedElements[0].name = secondElementName;

                LeanTween.move(selectedElements[1], firstElementPosition, 0.25f);
                selectedElements[1].GetComponent<CardTileInformation>().xValue = firstElementXValue;
                selectedElements[1].GetComponent<CardTileInformation>().yValue = firstElementYValue;
                selectedElements[1].name = firstElementName;


                selectedElements[0].GetComponent<CardTileInformation>().ResetNeighbours();
                selectedElements[1].GetComponent<CardTileInformation>().ResetNeighbours();

                selectedElements.Clear();

            }
            else if(!selectedElements[1].GetComponent<CardTileInformation>().neighbours.Contains(selectedElements[0]))
            {
                selectedElements.Clear();
            }
        }
   } 
}
