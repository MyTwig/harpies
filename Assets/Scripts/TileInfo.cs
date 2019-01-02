using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    [Serializable]
    public enum Terrain
    {
        Field,
        Woods,
        Mountain
    }

    public Terrain TileTerrain;
    public BaseBuilding buildingHere; //There can only be one building on a tile
    public bool hasBuilding; //For quick checking whether or not a construction has taken place
    public Vector2Int mapCoords; //The coordinates on the MapGrid that this Tile has

    private void Start()
    {
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        if (TileTerrain.Equals(Terrain.Field))
            r.color = Color.yellow;
        if (TileTerrain.Equals(Terrain.Woods))
            r.color = Color.green;
        if (TileTerrain.Equals(Terrain.Mountain))
            r.color = Color.gray;
    }
}