using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D rigidbody2d;
    public float movementSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.AddRelativeForce(new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed));
    }
}
