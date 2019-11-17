using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrap : MonoBehaviour
{
    private AudioSource trapSFX;
    private Transform moleTransform;

    private void Start()
    {
        moleTransform = FindObjectOfType<MoleController>().transform;
        trapSFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        if ((int)transform.position.x ==  (int)moleTransform.position.x
            && (int)transform.position.z == (int)moleTransform.position.z
            && (int)transform.position.y > (int)moleTransform.position.y)
        {
            if (!trapSFX.isPlaying)
            {
                trapSFX.Play();
            }
        }
        else
        {
            if (trapSFX.isPlaying)
            {
                trapSFX.Stop();
            }
        }
    }
}
