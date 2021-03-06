﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour

{
    string horizontalDirection;
    string verticalDirection;
    string x_Rotate;
    string y_Rotate;
    string A_Button, B_Button, X_Button, Y_Button;

    public delegate void JoystickAction();
    public static event JoystickAction OnMoveLeftJoystick;
    public static event JoystickAction OnMoveRightJoystick;

    

	void Awake ()
    {
        horizontalDirection = "Joystick Horizontal";
        verticalDirection = "Joystick Vertical";
        x_Rotate = "Mouse X";
        y_Rotate = "Mouse Y";
        A_Button = "A Button";
        B_Button = "B Button";
        X_Button = "X Button";
        Y_Button = "Y Button";
    }
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetButton(A_Button))
        {
           
        }
        else if(Input.GetButton(B_Button))
        {

        }
        else if(Input.GetButton(X_Button))
        {

        }
        else if(Input.GetButton(Y_Button))
        {

        }

        if(Input.GetAxis(horizontalDirection) != 0 || Input.GetAxis(verticalDirection) != 0)
        {

            Debug.Log("register joysticks!");

            do
            {
                if(OnMoveLeftJoystick != null || OnMoveRightJoystick != null)
                {
                    OnMoveLeftJoystick();
                    OnMoveRightJoystick();
                }
                
            }
            while (Input.GetAxis(horizontalDirection) != 0 || Input.GetAxis(verticalDirection) != 0);
        }
    }

 



}
