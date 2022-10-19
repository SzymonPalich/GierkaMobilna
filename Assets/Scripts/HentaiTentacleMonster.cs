using UnityEngine;

public class HentaiTentacleMonster : MonoBehaviour
{
    public int health = 1;

    public Sound sounds;

    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Torpedo"))
        {
            health -= 1;
            if (health == 0)
            {
                sounds.PlayJellyFishDeath();
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
