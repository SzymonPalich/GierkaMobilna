using Assets.Scripts;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject torpedo;
    public JoyButton joyButton;

    private AudioManager audioManager;
    private AudioSource audioSource;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (joyButton.Pressed && (Time.timeSinceLevelLoad > nextActionTime))
        {
            audioSource.PlayOneShot(audioManager.shoot);
            nextActionTime = Time.timeSinceLevelLoad + period;
            Instantiate(torpedo, transform.position, transform.rotation);
        }
    }
}
