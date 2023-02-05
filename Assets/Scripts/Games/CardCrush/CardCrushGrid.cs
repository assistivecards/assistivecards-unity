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
        rectTransform = GetComponent<RectTransform>();
        screenWidthQuo = (Screen.width - 2048);
        screenHeightQuo = (Screen.height / 15);
        SetUp();
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
        Debug.Log("screen height: " + screenHeightQuo);

        SetLeft(rectTransform, screenWidthQuo / (float)(Screen.width/675f));
        SetBottom(rectTransform, screenWidthQuo / (float)(Screen.height/25f));

// 610 -> 4.2  632,85|  484 -> 3.85 657 | 290 -> 3.6 649 | bölen sayısı screen width ile doğru orantılı büyücek şimdilik ort.değer 3.5

        if(screenHeightQuo >= 95)
        {
            this.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            SetBottom(rectTransform, screenHeightQuo);
        }
        if(screenHeightQuo >= 70 && screenHeightQuo < 95)
        {
            this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        // if(screenHeightQuo <= 300)
        // {
        //     this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        //     SetBottom(rectTransform, screenHeightQuo);
        // }
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
