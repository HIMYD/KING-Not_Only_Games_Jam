using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    //Make sound

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mole") || collision.CompareTag("Snake"))
        {
            //fall
        }
    }
}
