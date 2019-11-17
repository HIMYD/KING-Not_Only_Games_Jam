using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverock : MonoBehaviour
{
    bool moverock_;
    public float moveSpeed = 1;
    Vector3 movement = Vector3.back;
    public float move_distance = 0f;
    float final_pos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position.z);
        final_pos = transform.position.z - move_distance;
        Debug.Log(final_pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(moverock_)
        {
           
           transform.position += movement * moveSpeed * Time.deltaTime;
           if(transform.position.z <= final_pos)
            {
                moverock_ = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Snake") && other.gameObject.GetComponent<SnakeController>().button_a.state == KEY_STATE.KEY_DOWN)
        {
            moverock_ = true;
        }
    }
  
  
}
