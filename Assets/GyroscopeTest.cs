using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeTest : MonoBehaviour
{
    public float rotationSpeed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    protected float GetRotation()
    {
        return -(Input.acceleration.x * rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, GetRotation());
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        Quaternion deviceRotation = DeviceRotation.Get();


        GUILayout.Label("GyroDebug");
        // GUILayout.Label("input.gyro.attitude: " + GetRotation(Input.gyro.attitude));
        GUILayout.Label("input.gyro.attitude(fix): " + deviceRotation);
        GUILayout.Label("input.gyro.attitude(normal): " + GetRotation(Input.gyro.attitude));
        GUILayout.Label("input.gyro.attitude(euler): " + Input.acceleration.x);
    }


    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private static float calc()
    {
        Quaternion referenceRotation = Quaternion.identity;
        Quaternion deviceRotation = GetRotation(Input.gyro.attitude);
        Quaternion eliminationOfXY = Quaternion.Inverse(
            Quaternion.FromToRotation(referenceRotation * Vector3.forward,
                                      deviceRotation * Vector3.forward)
        );
        Quaternion rotationZ = eliminationOfXY * deviceRotation;
        float roll = rotationZ.eulerAngles.z;
        return roll;
    }

    private static Quaternion GetRotation(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
    }

}
