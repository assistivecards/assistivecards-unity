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

    private void Start() {
        SetUp();
        // burası daha sonra difficulty seçim ekranıyla entegre çağırılıcak
    }

    private void SetUp()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(i * spacing, j * spacing, 0), Quaternion.identity) as GameObject;
                cell.transform.parent = this.transform;
                cell.name = i + " , " + j + " tile";
                cell.GetComponent<CardCrushCell>().x = cell.transform.position.x;
                cell.GetComponent<CardCrushCell>().y = cell.transform.position.y;
                allCells.Add(cell.GetComponent<CardCrushCell>());
            }
        }
    }
}
