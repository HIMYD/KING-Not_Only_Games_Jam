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


    bool going_throw_vines = false;
    bool can_go_thrown_vines = false;
    public float go_up_speed = 2.5f;
    float go_up_distance = 1.6f;
    float go_down_distance = 0f;
    private Vector3 diggingDirection = Vector3.up;
    private Rigidbody rb;


    //ROTATION
    Quaternion targetRotation;
    public GameObject render_object;

    private void Start()
    {
        playerIndex = PlayerIndex.Two;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        state = GamePad.GetState(playerIndex);
        button_a.UpdateValue(state.Buttons.A);

        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);

        if (movement != Vector3.zero)
        {
            rb.velocity = movement * moveSpeed;
            targetRotation = Quaternion.LookRotation(movement);
            render_object.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.time);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        anim.SetFloat("speed", movement.magnitude);
        if(can_go_thrown_vines && button_a.state == KEY_STATE.KEY_DOWN)
        {
            going_throw_vines = true;
            diggingDirection.y = -diggingDirection.y;
        }
        if(going_throw_vines)
        {
            transform.position += diggingDirection * go_up_speed * Time.deltaTime;
            if (Mathf.Sign(diggingDirection.y) == 1f)
            {
                if (transform.position.y >= go_up_distance)
                {
                    transform.position = new Vector3(transform.position.x, go_up_distance, transform.position.z);
                    going_throw_vines = false;
                }
            }
            else if (Mathf.Sign(diggingDirection.y) == -1f)
            {
                if (transform.position.y <= go_down_distance)
                {
                    transform.position = new Vector3(transform.position.x, go_down_distance, transform.position.z);
                    going_throw_vines = false;
                }
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Vines"))
        {
            can_go_thrown_vines = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vines"))
        {
            can_go_thrown_vines = false;
        }
    }
  
}
