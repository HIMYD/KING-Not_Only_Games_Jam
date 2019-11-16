using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    private AudioSource touchRockSFX;

    private void Start()
    {
        touchRockSFX = GetComponentInChildren<AudioSource>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mole"))
        {
            bool playVibration = collision.gameObject.GetComponent<MoleController>().CollideWithRock();
            if (playVibration)
            {
                touchRockSFX.Play();
            }
        }
    }
}
