using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform cameraTrans;

    [Header("Rotate")]
    public float rotateSpeed = 10f;
    private bool rotatingCamera = false;
    private float targetRotation = 0f;
    //The angle at which it stops lerping and just sets the target rotation
    private float minAngle = 1f;

    Vector3 isometricUp = Vector3.zero;
    Vector3 isometricDown = Vector3.zero;
    Vector3 isometricLeft = Vector3.zero;
    Vector3 isometricRight = Vector3.zero;

    private void Start()
    {
        CalculateIsometricVectors();
        targetRotation = transform.rotation.eulerAngles.y;
        cameraTrans = transform.Find("Main Camera");
        //TODO: Recalculate when the camera moves
    }

    void CalculateIsometricVectors()
    {
        isometricUp = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.forward;
        isometricDown = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.back;
        isometricLeft = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.left;
        isometricRight = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.right;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetRotation = targetRotation + 90;
            rotatingCamera = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetRotation = targetRotation - 90;
            rotatingCamera = true;
        }

        if (rotatingCamera)
        {
            float currRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.y, targetRotation, rotateSpeed * Time.deltaTime);
            if (Mathf.Abs(currRotation - targetRotation) > minAngle)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currRotation, transform.rotation.eulerAngles.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation, transform.rotation.eulerAngles.z);
                rotatingCamera = false;
            }
            CalculateIsometricVectors();
        }
    }
}