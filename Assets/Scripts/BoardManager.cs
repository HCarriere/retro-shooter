using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int width = 100;
    public int height = 100;

    public GameObject[] outerWallTiles;
    public GameObject[] groundTiles;

    private Transform boardHolder;

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int i = -1; i < width + 1; i++)
        {
            for (int j = -1; j < height + 1; j++)
            {
                GameObject toInstanciate = groundTiles[0];
                if (i == -1 || i == width || j == -1 || j == height)
                {
                    toInstanciate = outerWallTiles[0];
                }
                GameObject instance = Instantiate(toInstanciate, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene()
    {
        BoardSetup();
    }
}
