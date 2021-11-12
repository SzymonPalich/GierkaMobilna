using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject EndingMenu;
    private LevelEnding levelEnding;
    private Player player;
    private bool damageCooldown = false;
    private float cooldown = 1.0f;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        levelEnding = canvas.GetComponent<LevelEnding>();
        player = gameObject.GetComponent<Player>();
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
            levelEnding.ShowMenu();
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
