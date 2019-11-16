﻿using System.Collections;
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
    private void Start()
    {
        playerIndex = PlayerIndex.One;
        
    }
    private void FixedUpdate()
    {
        state = GamePad.GetState(playerIndex);
        button_a.UpdateValue(state.Buttons.A);
        Debug.Log(button_a.state);
    }
    void Update()
    {
        
        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);
        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z) || button_a.state==KEY_STATE.KEY_DOWN)
        {
            Debug.Log("enter");
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
}
