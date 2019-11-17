using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_manage : MonoBehaviour
{
    [HideInInspector]
    public bool buttons_pressed = false;
    public GameObject button_snake;
    public GameObject button_mole;
    public float distance_movement;
    private float final_pos;
    public float door_speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        final_pos = gameObject.transform.position.y - distance_movement;
    }

    // Update is called once per frame
    void Update()
    {
        if(button_snake.gameObject.GetComponent<button_manage>().button_pressed && button_mole.gameObject.GetComponent<button_manage>().button_pressed)
        {

            buttons_pressed = true;

            if(final_pos < gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - door_speed * Time.deltaTime, gameObject.transform.position.z);
            }
        }

        
    }
}
