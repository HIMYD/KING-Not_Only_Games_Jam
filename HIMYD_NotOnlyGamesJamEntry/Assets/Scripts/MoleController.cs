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

    bool can_dig = false;

    [HideInInspector]
    public bool isInTree = false;
    [HideInInspector]
    public FallingTreeTrigger currTree = null;


    Animator anim;
    public float dig_down_distance = -1.2f;
    public float dig_up_distance = 2f;
    private void Start()
    {
        playerIndex = PlayerIndex.One;
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

        if ((Input.GetKeyDown(KeyCode.Z) || button_a.state==KEY_STATE.KEY_DOWN))
        {
            Debug.Log("pressed z");
            if (isInTree)
            {
                currTree.MakeTreeFall();
            }
            else if (can_dig)
            {
                digging = true;
              
            }
        }

        if (digging)
        {
            transform.position += diggingDirection * diggingSpeed * Time.deltaTime;
            //Is diggin' down
            if (Mathf.Sign(diggingDirection.y) == -1f)
            {
                if (transform.position.y <= dig_down_distance)
                {
                    transform.position = new Vector3(transform.position.x, dig_down_distance, transform.position.z);
                    digging = false;
                }
            }
            //Is diggin' up
            else if (Mathf.Sign(diggingDirection.y) == 1f)
            {
                if (transform.position.y >= dig_up_distance)
                {
                    transform.position = new Vector3(transform.position.x, dig_up_distance, transform.position.z);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole")  == true)
        {
            can_dig = true;
            diggingDirection.y = -1f;
        }
        if (other.gameObject.CompareTag("Holeup") == true)
        {

            can_dig = true;
            diggingDirection.y = 1f;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            can_dig = false;
        }
    }
}
