using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSystem : MonoBehaviour
{
    [HideInInspector]
    public List<MyTile> tiles;

    public MyTile GetTile(int x, int y, int z)
    {
        foreach (MyTile tile in tiles)
        {
            if((int)tile.transform.position.x == x
                && (int) tile.transform.position.y == y
                && (int) tile.transform.position.z == z)
            {
                return tile;
            }
        }
        return null;
    }
}
