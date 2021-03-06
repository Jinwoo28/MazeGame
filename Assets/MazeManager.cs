using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    private int with = 0;
    private int height = 0;

    [SerializeField] private Transform Cam = null;
    [SerializeField] private ParticleSystem FinishLine = null;

    private CellScr[,] cellmap;
    private List<CellScr> cellHistoryList;
    public CellScr cellPrefab;

    [SerializeField]
    private GameObject[] SpawnItem = null;
    void Start()
    {
        with = SystemManager.instance.GetGameLevel_();
        height = SystemManager.instance.GetGameLevel_();
        BatchCells();
        MakeMaze(cellmap[0, 0]);

        cellmap[with-1, height-1].isrightWall = false;
        Instantiate(FinishLine, cellmap[with - 1, height - 1].FloorWall.transform);
    }

    private void BatchCells()
    {
        cellmap =  new CellScr[with, height];
        cellHistoryList = new List<CellScr>();

        for(int x = 0; x < with; x++)
        {
            for(int y = 0; y < height; y++)
            {
                CellScr Cell = Instantiate<CellScr>(cellPrefab, this.transform);
                Cell.transform.localPosition = new Vector3(x * 5, 0, y * 5);
                Cell.index  =  new Vector2Int(x, y);
                cellmap[x, y] = Cell;

                int i = Random.Range(0, 10);
                int j = Random.Range(0, 3);
                if(i==1)
                {
                   GameObject tmp =  Instantiate(SpawnItem[j], cellmap[x, y].SpawnPoint.transform);
                    tmp.transform.localScale = Vector3.one;
                   tmp.GetComponent<Spawnitem>().Cam = Cam;
                   
                }
            }
        }
    }

    private void MakeMaze(CellScr startCell)
    {
        CellScr[] neighbors = GetNeighborCells(startCell);
        if (neighbors.Length > 0)
        {
            CellScr nextCell = neighbors[Random.Range(0, neighbors.Length)];
            ConnectCell(startCell, nextCell);
          
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else
        {
            if (cellHistoryList.Count > 0)
            {
                CellScr lastCell = cellHistoryList[cellHistoryList.Count - 1];
                cellHistoryList.Remove(lastCell);
                MakeMaze(lastCell);
 
            }
        }
    }

    private CellScr[] GetNeighborCells(CellScr standardell)
    {
        List<CellScr> RetCellList = new List<CellScr>();
        Vector2Int index = standardell.index;

        //forward
        if (index.y + 1 < height)
        {
            CellScr neighbor = cellmap[index.x, index.y + 1];
            if (neighbor.CheckAllWall()) 
            { 
                RetCellList.Add(neighbor); 
            }
        }
        //back
        if (index.y-1 >= 0)
        {
            CellScr neighbor = cellmap[index.x, index.y-1];
            if (neighbor.CheckAllWall())
            {
                RetCellList.Add(neighbor);
            }
        }
        //right
        if (index.x + 1 < with)
        {
            CellScr neighbor = cellmap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                RetCellList.Add(neighbor);
            }
        }
        //left
        if (index.x-1 >= 0)
        {
            CellScr neighbor = cellmap[index.x-1, index.y];
            if (neighbor.CheckAllWall())
            {
                RetCellList.Add(neighbor);
            }
        }
            return RetCellList.ToArray();
    }

    private void ConnectCell(CellScr c0, CellScr c1)
    {
        Vector2Int Dir = c0.index - c1.index;

        if (Dir.y <= -1)
        {
            c0.isforwordWall = false;
            c1.isbackWall = false;
           //Debug.Log("F");
        }
        else if (Dir.y >= 1)
        {
            c0.isbackWall = false;
            c1.isforwordWall = false;
        //    Debug.Log("B");
        }
        else if (Dir.x <= -1)
        {
            c0.isrightWall = false;
            c1.isleftWall = false;
       //     Debug.Log("R");
        }
        else if (Dir.x >= 1)
        {
            c0.isleftWall = false;
            c1.isrightWall = false;
       //     Debug.Log("L");
        }
        c0.ShowWall();
        c1.ShowWall();
    }

}
