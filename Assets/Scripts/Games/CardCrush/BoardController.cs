using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public int boardWidth;
    public int boardHeight;
    [SerializeField] private GameObject tempCardTilePrefab;
    private GameObject cardTileElement;
    private BackgroundTile[,] allCardTiles;

    void Start()
    {
        allCardTiles = new BackgroundTile[boardWidth, boardHeight];
        SetUp();
    }

    private void SetUp()
    {
        for(int i = 0; i < boardWidth; i++)
        {
            for(int j =0; j < boardHeight; j++)
            {
                Vector2 tempPosition = new Vector2(i * 150, j * 140);
                cardTileElement = Instantiate(tempCardTilePrefab, tempPosition, Quaternion.identity);
                cardTileElement.transform.parent = this.transform;
                cardTileElement.transform.localPosition = tempPosition;
                cardTileElement.name = i + " , " + j + " tile";
            } 
        }
    }
}
