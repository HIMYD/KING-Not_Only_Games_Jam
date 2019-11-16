using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class MoleController : MonoBehaviour
{


    public float moveSpeed = 2.5f;
    //public string digButton = "joystick button 0";

    private bool digging = false;
    private Vector3 diggingDirection = Vector3.up;
    public float diggingSpeed = 2.5f;


    //CONTROLLER
    PlayerIndex playerIndex;
    GamePadState state;
    button button_a = new button();
    bool canVibrate = true;
    float time_vibration;
    private void Start()
    {
        playerIndex = PlayerIndex.One;
        
    }
    private void FixedUpdate()
    {
       
    }
    void Update()
    {
        state = GamePad.GetState(playerIndex);
        button_a.UpdateValue(state.Buttons.A);

        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);
        if (movement != Vector3.zero)
        {
            Debug.Log(movement);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z) || button_a.state==KEY_STATE.KEY_DOWN)
        {
           
            digging = true;
            diggingDirection = -diggingDirection;
        }

        if (digging)
        {
            transform.position += diggingDirection * diggingSpeed * Time.deltaTime;
            //Is diggin' down
            if (Mathf.Sign(diggingDirection.y) ==  -1f)
            {
                if (transform.position.y <= -1f)
                {
                    transform.position = new Vector3(transform.position.x, -1, transform.position.z);
                    digging = false;
                }
            }
            //Is diggin' up
            else if (Mathf.Sign(diggingDirection.y) == 1f)
            {
                if (transform.position.y >= 0f)
                {
                    transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    digging = false;
                }
            }
        }
        if (!canVibrate && (Time.time - time_vibration) >= 0.5f)
        {
            GamePad.SetVibration(playerIndex, 0.0f, 0f);
            canVibrate = true;
        }
    }
    public bool CollideWithRock()
    {
        if (canVibrate)
        {
            Debug.Log("enter");
            GamePad.SetVibration(playerIndex, 0.1f, 0.1f);

            canVibrate = false;
            time_vibration = Time.time;
            return true;
        }
        return false;
    }
}
