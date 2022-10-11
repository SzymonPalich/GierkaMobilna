using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody2D playerRB;

    [SerializeField]
    protected float rotationSpeed = 1.2f;
    [SerializeField]
    protected float tiltDeadZone = 0.15f;

    [SerializeField]
    protected float movementSpeed = 3.0f;
    [SerializeField]
    protected float maxSpeed = 3.0f;
    [SerializeField]
    protected float maxSpeedSlowdown = 6.0f;
    [SerializeField]
    protected float slowdownRate = 6.0f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void FixedUpdate()
    {
        SpeedControl();
        JoystickInput();
        if (Abs(Input.acceleration.x) > tiltDeadZone)
        {
            playerRB.AddTorque(GetRotation() * rotationSpeed);
        }
    }

    void JoystickInput()
    {
        playerRB.AddRelativeForce(new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed));
    }

    void SpeedControl()
    {
        if (playerRB.velocity.x > maxSpeed)
        {
            playerRB.AddForce(new Vector2(-maxSpeedSlowdown, 0));
        }
        else if (playerRB.velocity.x < -maxSpeed)
        {
            playerRB.AddForce(new Vector2(maxSpeedSlowdown, 0));
        }

        if (playerRB.velocity.y > maxSpeed)
        {
            playerRB.AddForce(new Vector2(0, -maxSpeedSlowdown));
        }
        else if (playerRB.velocity.y < -maxSpeed)
        {
            playerRB.AddForce(new Vector2(0, maxSpeedSlowdown));
        }
    }

    protected float GetRotation()
    {
        return -(Input.acceleration.x * rotationSpeed);
    }

    protected float Abs(float value)
    {
        return (value > 0) ? value : -value;
    }
}
