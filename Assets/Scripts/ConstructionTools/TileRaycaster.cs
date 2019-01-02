using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileRaycaster
{

    public static TileInfo GetTileAtMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
        if (hit.collider != null)
        {
            return hit.collider.GetComponent<TileInfo>();
        }
        else
            return null;
    }

    public static List<TileInfo> GetTilesAroundOrigin(TileInfo origin, MapGrid map, int distance)
    {
        List<TileInfo> tiles = new List<TileInfo>();
        for (int x = distance * -1; x < distance; x++)
        {
            for (int y = distance * -1; y < distance; y++)
            {
                TileInfo t = map.GetTile(origin.mapCoords.x + x, origin.mapCoords.y + y);
                if (t != null)
                    tiles.Add(t);
            }
        }
        return tiles;
    }

    public static List<TileInfo> GetAdjacentTiles(TileInfo origin, MapGrid map)
    {
        return GetTilesAroundOrigin(origin, map, 1);
    }
}
