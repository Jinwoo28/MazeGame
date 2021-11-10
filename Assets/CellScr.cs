using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScr : MonoBehaviour
{
    public Vector2Int index;

    public bool isforwordWall = true;
    public bool isbackWall = true;
    public bool isrightWall = true;
    public bool isleftWall = true;

    public GameObject forwardWall = null;
    public GameObject backWall = null;
    public GameObject rightWall = null;
    public GameObject leftWall = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowWall();
    }

    public void ShowWall()
    {
        forwardWall.SetActive(isforwordWall);
        backWall.SetActive(isbackWall);
        rightWall.SetActive(isrightWall);
        leftWall.SetActive(isleftWall);
    }

    public bool CheckAllWall()
    {
        return isforwordWall && isbackWall && isleftWall && isrightWall;
    }
}
