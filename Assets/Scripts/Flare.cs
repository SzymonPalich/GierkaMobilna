using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flare : MonoBehaviour
{
    public Animator animator;
    private Light2D flareLight;
    private bool setOn = false;

    public int size = 8;
    public float maxRadius = 4.0f;
    public float minRadius = 0.5f;
    public float radiusIncreaseSpeed = 0.01f;

    private float innerRadiusMin;
    private float outerRadiusMin;

    void Start()
    {
        innerRadiusMin = minRadius;
        outerRadiusMin = 2 * innerRadiusMin;

        flareLight = GetComponent<Light2D>();

        flareLight.pointLightInnerRadius = innerRadiusMin;
        flareLight.pointLightOuterRadius = outerRadiusMin;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            setOn = true;
            animator.SetBool("SetOn", true);
        }
    }

    private void Update()
    {
        if (setOn && (flareLight.pointLightInnerRadius <= maxRadius))
        {
            flareLight.pointLightInnerRadius += radiusIncreaseSpeed;
            flareLight.pointLightOuterRadius += 2 * radiusIncreaseSpeed;
        }
    }
}
