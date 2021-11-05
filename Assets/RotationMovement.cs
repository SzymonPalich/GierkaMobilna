using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d; // tylko do debugowania
    public float rotationSpeed = 12f;
    public float tiltDeadZone = 1.2f;
    // Start is called before the first frame update

    protected float currentRotation;
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
        currentRotation = GetRotation();
        if (abs(currentRotation) > tiltDeadZone)
        {
            transform.Rotate(0, 0, currentRotation);
        }
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        GUILayout.Label("GyroDebug");
        GUILayout.Label("Rotation: " + GetRotation());
        GUILayout.Label("Speed: " + rigidbody2d.velocity);
        // GUILayout.Label("Speed(rel): " + );
    }

    protected float GetRotation()
    {
        return -(Input.acceleration.x * rotationSpeed);
    }

    protected float abs(float value)
    {
        return (value > 0) ? value : -value;
    }
}
