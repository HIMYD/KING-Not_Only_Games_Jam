using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class SimplestMovementController : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;

    public float movementSpeed = 10f;
    public float minDistance = 0.1f;
    private List<Vector3> positions;

    public PlayerIndex playerIndex;
    private GamePadState state;

    private AudioSource audioSource;

    //Quaternion targetRotation;
    //public GameObject render_object;

    public button button_down = new button();
    public button button_up = new button();
    public button button_left = new button();
    public button button_right = new button();

    public AudioClip moveSFX;
    public AudioClip invalidMoveSFX;

    private TileSystem tileSystem;

    private LoseGame loseGame;

    [Tooltip("0 for snake, -2 for mole")]
    public int height;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tileSystem = FindObjectOfType<TileSystem>();
        loseGame = FindObjectOfType<LoseGame>();
        positions = new List<Vector3>();
    }

    private void Update()
    {
        state = GamePad.GetState(playerIndex);
        button_down.UpdateValue(state.DPad.Down);
        button_up.UpdateValue(state.DPad.Up);
        button_left.UpdateValue(state.DPad.Left);
        button_right.UpdateValue(state.DPad.Right);

        AddNewPositions();

        if (positions.Count > 0)
        {
            transform.position = Vector3.Lerp(transform.position, positions[0], Time.deltaTime * movementSpeed);
            if (Vector3.Distance(transform.position, positions[0]) < minDistance)
            {
                transform.position = positions[0];
                positions.RemoveAt(0);
            }
        }
    }

    private void AddNewPositions()
    {
        if (button_down.state == KEY_STATE.KEY_DOWN ||
            Input.GetKeyDown(back))
        {
            PressedLetter(Vector3.back);
        }
        if (button_up.state == KEY_STATE.KEY_DOWN ||
            Input.GetKeyDown(forward))
        {
            PressedLetter(Vector3.forward);
        }
        if (button_left.state == KEY_STATE.KEY_DOWN ||
            Input.GetKeyDown(left))
        {
            PressedLetter(Vector3.left);
        }
        if (button_right.state == KEY_STATE.KEY_DOWN ||
            Input.GetKeyDown(right))
        {
            PressedLetter(Vector3.right);
        }
    }

    private void PressedLetter(Vector3 direction)
    {
        Vector3 lastPosition = GetLastPosition();
        Vector3 newPosition = lastPosition + direction;
        //This should be executed when it moves, not when it presses the input
        MyTile tileAtPos = tileSystem.GetTile((int)newPosition.x, height, (int)newPosition.z);
        if (tileAtPos == null)
        {
            if (audioSource != null)
            {
                audioSource.clip = invalidMoveSFX;
                audioSource.Play();
            }
        }
        else
        {
            switch (tileAtPos.type)
            {
                case TileType.rock:
                    if (audioSource != null)
                    {
                        audioSource.clip = invalidMoveSFX;
                        audioSource.Play();
                    }
                    break;
                case TileType.trap:
                    positions.Add(newPosition);
                    loseGame.LostGame();
                    break;
                case TileType.ground:
                    positions.Add(newPosition);
                    if (audioSource != null)
                    {
                        audioSource.clip = moveSFX;
                        audioSource.Play();
                    }
                    break;
            }
        }
    }

    private Vector3 GetLastPosition()
    {
        if (positions.Count > 0)
        {
            return positions[positions.Count - 1];
        }
        else
        {
            return transform.position;
        }
    }
}
