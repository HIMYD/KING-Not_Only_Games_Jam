using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public GameObject basicBlock;
    public GameObject rockBlock;
    public GameObject fallBlock;

    public int terrainWidth = 15;
    public int terrainDepth = 15;


    void Start()
    {
        float halfWidth = terrainWidth * 0.5f;
        float halfDepth = terrainDepth * 0.5f;
        for (float x = -halfWidth; x < halfWidth; ++x)
        {
            for (float z = -halfDepth; z < halfDepth; ++z)
            {
                Vector3 position = new Vector3(x, 0f, z);
                Instantiate(basicBlock, position, Quaternion.identity);
            }
        }
    }
}
