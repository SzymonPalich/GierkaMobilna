using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d; // tylko do debugowania
    public float rotationSpeed = 12f;
    public float tiltDeadZone = 1.2f;
    // Start is called before the first frame update

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Abs(Input.acceleration.x) > tiltDeadZone)
        {
            // transform.Rotate(0, 0, GetRotation());
            rigidbody2d.AddTorque(GetRotation() * rotationSpeed);
        }
        // RotationSlowdown();
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        GUILayout.Label("Gyro DEBÜÜÜG :D :D");
        GUILayout.Label("Rotation: " + Input.acceleration.x);
        GUILayout.Label("Speed: " + rigidbody2d.velocity);
        GUILayout.Label("Angular: " + rigidbody2d.angularVelocity);
        // GUILayout.Label("Speed(rel): " + );
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
