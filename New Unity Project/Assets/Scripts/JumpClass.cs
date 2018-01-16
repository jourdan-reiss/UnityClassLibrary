using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpClass : MonoBehaviour , ICommand
{

    Rigidbody rb;
    bool isPlayerGrounded;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        PlayerOnTheGround();
	}
	
	void FixedUpdate ()
    {
		
	}

    bool PlayerOnTheGround()
    {
        return isPlayerGrounded = true;
    }

    bool PlayerInTheAir()
    {
        return isPlayerGrounded = false;
    }

    Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = rb.position;
        return playerPosition;
    }

    Vector3 GetPlayerVelocity()
    {
        Vector3 playerInitialVelocity = rb.velocity;
        return playerInitialVelocity;
    }

    public void Execute()
    {
        Jump();
    }

    //need velocity along the horizontal, velocity in the vertical. These combine to give the 3-dimensional velocity of the player once the jump begins. 
    //look up simplified velocity verlet to correctly integrate to find new position and velocity. 
    //assume the velocity will be consistent; movement speed will be set in separate class and will be constant.
    //gravity is also likely a consistent force, will need to set. Create some parabolas which seem to simulate the best jumps and then work on making code
    //that can handle these scenarios.


    void Jump(Vector3 position, Vector3 velocity, Vector3 jumpVelocity)
    {
        
    }

}
