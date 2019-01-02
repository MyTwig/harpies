using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{ //Container for the map

    [SerializeField]
    readonly int width, height;
    private TileInfo[,] tiles;
    [SerializeField]
    GameObject mapParent;

    void Start()
    {
        tiles = new TileInfo[width, height];
        //Create the array and populate it with empty TileInfo objects
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject o = new GameObject("Tile");
                o.transform.SetParent(mapParent.transform);
                o.AddComponent<TileInfo>();
            }
        }
    }

    TileInfo GetTile(int x, int y)
    {
        if (x > width || y > height)
        {
            Debug.LogError("X or Y is outside of array bounds!");
            return null;
        }
        else
        {
            return tiles[x, y];
        }
    }



}
