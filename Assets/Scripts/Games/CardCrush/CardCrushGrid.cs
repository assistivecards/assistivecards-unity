using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCrushGrid : MonoBehaviour
{
    [Header ("Create Board")]
    public int width;
    public int height;
    public int spacing;

    [SerializeField] private GameObject cellPrefab;
    public List<CardCrushCell> allCells = new List<CardCrushCell>();

    private float screenWidthQuo;
    private float screenHeightQuo;
    RectTransform rectTransform;

    private void Start() 
    {
        GetGrid();
        //SetUp();
    }

    public void SetUp()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject cell = Instantiate(cellPrefab, tempPosition * spacing, Quaternion.identity) as GameObject;
                cell.transform.parent = this.transform;
                cell.name = i + " , " + j + " tile";
                cell.GetComponent<CardCrushCell>().x = i;
                cell.GetComponent<CardCrushCell>().y = j;
                allCells.Add(cell.GetComponent<CardCrushCell>());
            }
        }
    }

    private void GetGrid()
    {
        
        foreach(Transform child in transform)
        {
            allCells.Add(child.GetComponent<CardCrushCell>());
        }
    }

    public static void SetLeft(RectTransform _rect, float left)
    {
        _rect.offsetMin = new Vector2(left, _rect.offsetMin.y);
    }

    public static void SetBottom(RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
}
