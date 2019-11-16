using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mole"))
        {
            collision.gameObject.GetComponent<MoleController>().Vibrate();
        }
    }
}
