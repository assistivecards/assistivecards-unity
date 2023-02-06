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
        Debug.Log("SCREEN height: " + screenHeightQuo);

        SetLeft(rectTransform, screenWidthQuo / (float)(Screen.width/675f));
        SetBottom(rectTransform, screenWidthQuo / (float)(Screen.height/25f));

        if(screenHeightQuo > 105)
        {
            SetBottom(rectTransform, screenHeightQuo * 1.25f);
        }
        else if(screenHeightQuo >= 100 && screenHeightQuo <= 105)
        {
            this.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            SetBottom(rectTransform, screenHeightQuo * 1.1f);
        }
        else if(screenHeightQuo >= 95 && screenHeightQuo < 100)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
            SetBottom(rectTransform, screenHeightQuo * 0.5f);
        }
        else if(screenHeightQuo >= 85 && screenHeightQuo < 95)
        {
            SetLeft(rectTransform, screenWidthQuo / (float)(Screen.width/630));
            SetBottom(rectTransform, screenHeightQuo * 0.5f);
        }
        else if(screenHeightQuo < 85 && screenHeightQuo >= 60)
        {
            this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            SetBottom(rectTransform, screenHeightQuo * 0.5f);
        }
        else if(screenHeightQuo < 60)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            SetBottom(rectTransform, screenHeightQuo * 0.5f);
            SetLeft(rectTransform, screenWidthQuo / (float)(Screen.width/410f));
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
