using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject torpedo;
    public JoyButton joyButton;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    void Update()
    {
        if (joyButton.Pressed && (Time.timeSinceLevelLoad > nextActionTime))
        {
            nextActionTime = Time.timeSinceLevelLoad + period;
            Instantiate(torpedo, transform.position, transform.rotation);
        }
    }
}
