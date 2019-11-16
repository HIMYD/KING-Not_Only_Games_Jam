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
    [HideInInspector]
    public button button_a = new button();
    bool rock_vibration = true;
    float time_vibration;
    public float vibrate_rock_time = 0.2f;
    [HideInInspector]
    public bool isInTree = false;
    [HideInInspector]
    public FallingTreeTrigger currTree = null;

    private void Start()
    {
        playerIndex = PlayerIndex.One;
        
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

        if (Input.GetKeyDown(KeyCode.Z) || button_a.state==KEY_STATE.KEY_DOWN)
        {
            if (isInTree)
            {
                currTree.MakeTreeFall();
            }
            else
            {
                digging = true;
                diggingDirection = -diggingDirection;
            }
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

        if (!rock_vibration && (Time.time - time_vibration) >= vibrate_rock_time)
        {
            GamePad.SetVibration(playerIndex, 0.0f, 0f);
            rock_vibration = true;
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
        

    }
}
