using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_up : MonoBehaviour
{
    public string player_tag;
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
        if (other.CompareTag(player_tag))
        {
            if(player_tag=="Mole")
            {
                other.gameObject.GetComponent<MoleController>();

            }
            else if(player_tag == "Snake")
            {
                other.gameObject.GetComponent<SnakeController>().go_up_distance = distance;

            }
        }
    }
    
}
