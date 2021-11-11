using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Rigidbody2D PlayerRB;
    public GameObject torpedo;
    public JoyButton joyButton;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    void Start()
    {
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joyButton.Pressed && (Time.timeSinceLevelLoad > nextActionTime))
        {
            nextActionTime = Time.timeSinceLevelLoad + period;
            GameObject torpedoObj = Instantiate(torpedo, transform.position, transform.rotation);
        }
    }
}
