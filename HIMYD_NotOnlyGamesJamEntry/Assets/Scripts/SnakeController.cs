using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 2.5f;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (movement != Vector3.zero)
        {
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}
