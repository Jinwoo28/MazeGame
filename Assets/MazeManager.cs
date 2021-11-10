using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public int with = 5;
    public int height = 5;

    private CellScr[,] cellmap;

    public CellScr cellPrefab;
    void Start()
    {
        BatchCells();
        MakeMaze(cellmap[0, 0]);
    }

    private void BatchCells()
    {
        cellmap =  new CellScr[with, height];
      
        for(int x = 0; x < with; x++)
        {
            for(int y = 0; y < height; y++)
            {
                CellScr Cell = Instantiate<CellScr>(cellPrefab, new Vector3(x, 0, y), Quaternion.identity);
                Cell.transform.localPosition = new Vector3(x * 5, 0, y * 5);
                Cell.index  =  new Vector2Int(x, y);
                cellmap[x, y] = Cell;
            }
        }
    }

    private void MakeMaze(CellScr startCell)
    {

    }

    //private CellScr[] GetNeighborCells(CellScr standardell)
    //{

    //}

}
