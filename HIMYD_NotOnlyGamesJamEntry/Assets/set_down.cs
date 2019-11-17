using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_down : MonoBehaviour
{
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mole"))
        {
            other.gameObject.GetComponent<MoleController>().dig_down_distance = distance;
        }
    }
}
