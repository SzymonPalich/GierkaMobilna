using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Player player;

    private bool damageCooldown = false;
    private readonly float cooldown = 1.0f;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hurt")
        {
            player.TakeDamageCollison();
            Handheld.Vibrate();
        }
        else if (col.tag == "Finish")
        {
            player.GameMenus.ShowLevelEndUI();
        }
        else if (col.tag == "Enemy" && !damageCooldown)
        {
            Destroy(col.transform.parent.gameObject);
            player.TakeDamage(50);
            StartCoroutine(DamageCooldown(cooldown));
        }
        else if (col.tag == "AngryFish" && !damageCooldown)
        {
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
