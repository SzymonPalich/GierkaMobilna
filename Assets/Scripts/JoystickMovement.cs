using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D rigidbody2d;
    public float movementSpeed;
    public float maxSpeed = 3.0f;
    public float maxSpeedSlowdown = 6.0f;
    public float slowdownRate = 6.0f;

    void Start()
    {
        
    }

    void Update()
    {
        SpeedControl();
        JoystickInput();
        SlowDown();
    }

    void JoystickInput()
    {
        rigidbody2d.AddRelativeForce(new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed));
    }

    void SpeedControl()
    {
        if (rigidbody2d.velocity.x > maxSpeed)
        {
            rigidbody2d.AddForce(new Vector2(-maxSpeedSlowdown, 0));
        }
        else if (rigidbody2d.velocity.x < -maxSpeed)
        {
            rigidbody2d.AddForce(new Vector2(maxSpeedSlowdown, 0));
        }

        if (rigidbody2d.velocity.y > maxSpeed)
        {
            rigidbody2d.AddForce(new Vector2(0, -maxSpeedSlowdown));
        }
        else if (rigidbody2d.velocity.y < -maxSpeed)
        {
            rigidbody2d.AddForce(new Vector2(0, maxSpeedSlowdown));
        }
    }

    void SlowDown()
    {
        if (rigidbody2d.velocity.x != 0)
        {
            rigidbody2d.AddForce(new Vector2(-(rigidbody2d.velocity.x / slowdownRate), -(rigidbody2d.velocity.y / slowdownRate)));
        } 
    }
}
