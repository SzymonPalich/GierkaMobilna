using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D rigidbody2d;
    public float movementSpeed;
    public float maxSpeed;
    public float slowdownRate = 6f
        
        ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SlowDown();
        rigidbody2d.AddRelativeForce(new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed));
    }

    void SlowDown()
    {
        if (rigidbody2d.velocity.x != 0)
        {
            // rigidbody2d.AddRelativeForce(new Vector2(-(rigidbody2d.velocity.x / slowdownRate), -(rigidbody2d.velocity.y / slowdownRate)));
            rigidbody2d.AddForce(new Vector2(-(rigidbody2d.velocity.x / slowdownRate), -(rigidbody2d.velocity.y / slowdownRate)));
        } 
    }
}
