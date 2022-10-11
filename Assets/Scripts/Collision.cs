using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Player player;
    public GameMenus gameMenus;

    private AudioManager audioManager;
    private AudioSource audioSource;

    private bool damageCooldown = false;
    private readonly float cooldown = 1.0f;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hurt"))
        {
            player.TakeDamageCollison();
            Handheld.Vibrate();
            audioSource.PlayOneShot(audioManager.wallStuck);

        }
        else if (col.CompareTag("Finish"))
        {
            audioSource.PlayOneShot(audioManager.levelEnd);
            gameMenus.ShowLevelEndUI();
        }
        else if (col.CompareTag("Enemy") && !damageCooldown)
        {
            audioSource.PlayOneShot(audioManager.mineExplosion);
            Destroy(col.transform.parent.gameObject);
            player.TakeDamage(50);
            StartCoroutine(DamageCooldown(cooldown));
        }
        else if (col.CompareTag("AngryFish") && !damageCooldown)
        {
            audioSource.PlayOneShot(audioManager.wallStuck);
            player.TakeDamage(30);
            StartCoroutine(DamageCooldown(cooldown));
        }
    }

    IEnumerator DamageCooldown(float cooldown)
    {
        damageCooldown = true;
        yield return new WaitForSeconds(cooldown);
        damageCooldown = false;
    }
}
