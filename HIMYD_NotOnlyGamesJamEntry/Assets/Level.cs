﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 position = Vector3.zero; 
    public Vector3 separation = Vector3.zero;
    public Vector3 number = Vector3.zero;

    public void CreateCopiesXYZ(ref Vector3 position, int numX, int numY, int numZ)
    {
        position.x = 0f;
        for (int i = 0; i < numX; ++i)
        {
            if (numY != 0)
            {
                CreateCopiesYZ(ref position, numX, numY, numZ);
            }
            else if (numZ != 0)
            {
                CreateCopiesZ(ref position, numX, numY, numZ);
            }
            else
            {
                Instantiate(gameObject, position, Quaternion.identity);
            }
            position.x += separation.x;
        }
    }

    public void CreateCopiesYZ(ref Vector3 position, int numX, int numY, int numZ)
    {
        position.y = 0f;
        for (int j = 0; j < numY; ++j)
        {
            if (numZ != 0)
            {
                CreateCopiesZ(ref position, numX, numY, numZ);
            }
            else
            {
                Instantiate(gameObject, position, Quaternion.identity);
            }
            position.y += separation.y;
        }
    }

    public void CreateCopiesZ(ref Vector3 position, int numX, int numY, int numZ)
    {
        position.z = 0f;
        for (int k = 0; k < numZ; ++k)
        {
            Instantiate(gameObject, position, Quaternion.identity);
            position.z += separation.z;
        }
    }
}

