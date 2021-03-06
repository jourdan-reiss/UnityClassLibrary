﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    string horizontalDirection;
    string verticalDirection;
    string x_Rotate;
    string y_Rotate;

    public float turnSpeed;
    public float movementSpeed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputController.OnMoveLeftJoystick += Moving;
        InputController.OnMoveRightJoystick += Turning;
    }

    private void OnDisable()
    {
        InputController.OnMoveLeftJoystick -= Moving;
        InputController.OnMoveRightJoystick -= Turning;
    }

    void Moving()
    {
        float xVelocity = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float yVelocity = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(xVelocity);
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            Move(yVelocity);
        }
    }

    void Move(float speedParameter)
    {
        Vector3 movement = transform.forward * speedParameter;
        rb.AddForce(movement);
    }

    void Turning()
    {
        float x_turnVelocity = Input.GetAxis("Rotate Horizontal") * turnSpeed * Time.deltaTime;
        float y_turnVelocity = Input.GetAxis("Rotate Vertical") * turnSpeed * Time.deltaTime;

        if (Input.GetAxis("Rotate Horizontal") != 0)
        {
            Vector3 x_rotationVelocity = new Vector3(x_turnVelocity, 0f, 0f);
            Turn(x_rotationVelocity);
        }
        else if (Input.GetAxis("Rotate Vertical") != 0)
        {
            Vector3 y_rotationVelocity = new Vector3(0f, y_turnVelocity, 0f);
            Turn(y_rotationVelocity);
        }
    }

    void Turn(Vector3 rotationVelocity)
    {
        Quaternion turn = Quaternion.Euler(rotationVelocity);
        rb.MoveRotation(turn);
    }
}
