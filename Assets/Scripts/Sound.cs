using Assets.Scripts;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioManager audioManager;
    private AudioSource audioSource;

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMineExplosion()
    {
        audioSource.PlayOneShot(audioManager.mineExplosion);
    }

    public void PlayFishDeath()
    {
        audioSource.PlayOneShot(audioManager.fishDeath);
    }

    public void PlayJellyFishDeath()
    {
        audioSource.PlayOneShot(audioManager.reeeeeee);
    }
}
