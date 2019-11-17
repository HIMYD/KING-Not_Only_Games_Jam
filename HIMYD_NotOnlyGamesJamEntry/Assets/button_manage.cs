using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class button_manage : MonoBehaviour
{
    
    public bool button_pressed = false;
    public bool snake_button = false;
    public bool mole_button = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (snake_button)
        {
            if (other.gameObject.CompareTag("Snake") && other.gameObject.GetComponent<SnakeController>().button_a.state == KEY_STATE.KEY_DOWN)
            {
                button_pressed = true;
            }
        }

        else if (mole_button)
        {
            if (other.gameObject.CompareTag("Mole") && other.gameObject.GetComponent<MoleController>().button_a.state == KEY_STATE.KEY_DOWN)
            {
                button_pressed = true;
            }
        }
    }
}
