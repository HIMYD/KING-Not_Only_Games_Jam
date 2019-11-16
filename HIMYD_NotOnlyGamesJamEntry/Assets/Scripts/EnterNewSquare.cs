using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNewSquare : MonoBehaviour
{
    private AudioSource newSquareSFX;

    private void Start()
    {
        newSquareSFX = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            newSquareSFX.Play();
        }
    }
}