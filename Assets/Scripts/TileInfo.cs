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


}