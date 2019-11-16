using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class MoleController : MonoBehaviour
{


    public float moveSpeed = 2.5f;
    //public string digButton = "joystick button 0";

    private bool moving = false;
    private Vector3 diggingDirection = Vector3.up;
    public float diggingSpeed = 2.5f;


    //CONTROLLER
    PlayerIndex playerIndex;
    GamePadState state;
    button button_a = new button();
    bool rock_vibration = true;
    float time_vibration;
    private void Start()
    {
        playerIndex = PlayerIndex.One;
        
    }
    private void FixedUpdate()
    {
        state = GamePad.GetState(playerIndex);
        button_a.UpdateValue(state.Buttons.A);
    
    }
    void Update()
    {
        button_a.UpdateValue(state.Buttons.A);

        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);
        if (movement != Vector3.zero)
        {
            //Ray
            //if (Physics.Raycast())
            //{

            //}
            transform.position += movement;
        }

        if (Input.GetKeyDown(KeyCode.Z) || button_a.state==KEY_STATE.KEY_DOWN)
        {
           
            moving = true;
            diggingDirection = -diggingDirection;
        }

        if (moving)
        {
            transform.position += diggingDirection * diggingSpeed * Time.deltaTime;
            //Is diggin' down
            if (Mathf.Sign(diggingDirection.y) ==  -1f)
            {
                if (transform.position.y <= -1f)
                {
                    transform.position = new Vector3(transform.position.x, -1, transform.position.z);
                    moving = false;
                }
            }
            //Is diggin' up
            else if (Mathf.Sign(diggingDirection.y) == 1f)
            {
                if (transform.position.y >= 0f)
                {
                    transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    moving = false;
                }
            }
        }
    }
    public void Vibrate()
    {
        if (rock_vibration)
        {
            Debug.Log("enter");
            GamePad.SetVibration(playerIndex, 0.1f, 0.1f);
            rock_vibration = false;
            time_vibration = Time.time;
        }
        if(!rock_vibration && (Time.time - time_vibration) >= 1)
        {
            GamePad.SetVibration(playerIndex, 0.0f, 0f);
            rock_vibration = true;
        }

    }
}
