using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    trap,
    ground,
    rock,
}

public class MyTile : MonoBehaviour
{
    TileSystem tileSystem;
    public TileType type;

    private void Start()
    {
        tileSystem = FindObjectOfType<TileSystem>();
        tileSystem.tiles.Add(this);
    }
}
