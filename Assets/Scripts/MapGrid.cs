using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{ //Container for the map

    private int width, height;
    private TileInfo[,] tiles;
    [SerializeField]
    GameObject mapParent;
    [SerializeField]
    GameObject tilePrefab;

    public static MapFlags flags;

    string map = "fff" + Environment.NewLine + "fwf" + Environment.NewLine + "ffm"; //A plaintext file that describes the map

    void Start()
    {
        flags = new MapFlags();
        ParseMap();
    }

    public void ParseMap()
    {
        width = map.IndexOf(Environment.NewLine);
        string parseMap = string.Empty;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i].Equals('\n'))
            {
                height++;
            }
        }
        height++; //Adding +1 to height because there won't be a newline at the end of a map string
        parseMap = map;
        parseMap = parseMap.Replace("\n", string.Empty);
        parseMap = parseMap.Replace("\r", string.Empty);
        Debug.Log("Map is size " + width + ", " + height);
        tiles = new TileInfo[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = GameObject.Instantiate(tilePrefab);
                tile.transform.SetParent(mapParent.transform);
                tile.transform.position = new Vector3(x, y * -1, 0);
                TileInfo info = tile.GetComponent<TileInfo>();
                info.mapCoords = new Vector2Int(x, y);
                char c = parseMap[x * width + y];
                if (c.Equals('f'))
                    info.TileTerrain = TileInfo.Terrain.Field;
                if (c.Equals('w'))
                    info.TileTerrain = TileInfo.Terrain.Woods;
                if (c.Equals('m'))
                    info.TileTerrain = TileInfo.Terrain.Mountain;
            }
        }
    }

    public TileInfo GetTile(int x, int y)
    {
        if (x > width || y > height)
        {
            Debug.Log("X or Y is outside of array bounds, returning null");
            return null;
        }
        else
        {
            return tiles[x, y];
        }
    }



}
