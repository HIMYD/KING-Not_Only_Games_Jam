using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    //CONTROLLER
    PlayerIndex playerIndex;
    GamePadState state;
   public button button_a = new button();

    Animator anim;


    bool going_up = false;
    bool can_go_up = false;
    public float go_up_speed = 2.5f;
    float go_up_distance = 1.6f;
    private Vector3 diggingDirection = Vector3.up;
    private void Start()
    {
        playerIndex = PlayerIndex.Two;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        state = GamePad.GetState(playerIndex);
        button_a.UpdateValue(state.Buttons.A);

        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);
        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
        anim.SetFloat("speed", movement.magnitude);
        if(can_go_up && button_a.state == KEY_STATE.KEY_DOWN)
        {
            going_up = true;
        }
        if(going_up)
        {
            transform.position += diggingDirection * go_up_speed * Time.deltaTime;
            if (Mathf.Sign(diggingDirection.y) == 1f)
            {
                if (transform.position.y >= go_up_distance)
                {
                    transform.position = new Vector3(transform.position.x, go_up_distance, transform.position.z);
                    going_up = false;
                }
            }
               
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Vines"))
        {
           
            can_go_up = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vines"))
        {
            can_go_up = false;
        }
    }
  
}
