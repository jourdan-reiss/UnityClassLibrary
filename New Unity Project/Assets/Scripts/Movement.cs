using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{

    float xVelocity;
    float yVelocity;

    string horizontalDirection;
    string verticalDirection;
    string x_Rotate;
    string y_Rotate;

    public float turnSpeed;
    public float movementSpeed;

    Rigidbody rb;

    public Movement (Rigidbody rb, float movementSpeed, float turnSpeed)
    {
        this.rb = rb;
        this.turnSpeed = turnSpeed;
        this.movementSpeed = movementSpeed;
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
        xVelocity = Input.GetAxis(horizontalDirection) * movementSpeed * Time.deltaTime;
        yVelocity = Input.GetAxis(verticalDirection) * movementSpeed * Time.deltaTime;

        if (Input.GetAxis(horizontalDirection) != 0)
        {
            Move(xVelocity);
        }
        else if (Input.GetAxis(verticalDirection) != 0)
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
        float x_turnVelocity = Input.GetAxis(x_Rotate) * turnSpeed * Time.deltaTime;
        float y_turnVelocity = Input.GetAxis(y_Rotate) * turnSpeed * Time.deltaTime;

        if (Input.GetAxis(x_Rotate) != 0)
        {
            Vector3 x_rotationVelocity = new Vector3(x_turnVelocity, 0f, 0f);
            Turn(x_rotationVelocity);
        }
        else if (Input.GetAxis(y_Rotate) != 0)
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
