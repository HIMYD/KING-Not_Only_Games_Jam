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
    private void Start()
    {
        playerIndex = PlayerIndex.Two;

    }

    void Update()
    {
        state = GamePad.GetState(playerIndex);
        Vector3 movement = new Vector3(state.ThumbSticks.Left.X, 0f, state.ThumbSticks.Left.Y);
        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}
