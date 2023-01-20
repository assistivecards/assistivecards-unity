using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int gridWidth, gridHeight;
    public float verticalSpacing;
    public float horizontalSpacing;
    public List<GameObject> gridTiles = new List<GameObject>();
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject grid;

    private void Start() {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x * verticalSpacing * 100, y * horizontalSpacing * 100, 0), Quaternion.identity);
                spawnedTile.name = "tile: " + x + y;
                spawnedTile.transform.parent = grid.transform;
                spawnedTile.GetComponent<Tile>().x = x;
                spawnedTile.GetComponent<Tile>().y = y;
                gridTiles.Add(spawnedTile.gameObject);
            }
        }

        this.transform.localPosition =  new Vector3(143, 121, 0);
    }
}
