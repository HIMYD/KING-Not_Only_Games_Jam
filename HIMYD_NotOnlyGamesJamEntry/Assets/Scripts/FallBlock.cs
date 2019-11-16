using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    public float fallSpeed = 10f;
    bool movingDown = false;
    //TODO: Add acceleration
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mole") || other.CompareTag("Snake"))
        {
            movingDown = true;
        }
    }

    private void Update()
    {
        if (movingDown)
        {
            transform.parent.position += fallSpeed * Vector3.down * Time.deltaTime;
        }
    }
}
