using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileHolder : MonoBehaviour
{
    public int x;
    public int y;
    public int listNum;

    public EmptyTileHolder(int X, int Y, int ListNum)
    {
        X = x;
        Y = y;
        ListNum = listNum;
    }

    public List<EmptyTileHolder> emptyTiles = new List<EmptyTileHolder>();


    // empty tile creator should be here!

}
