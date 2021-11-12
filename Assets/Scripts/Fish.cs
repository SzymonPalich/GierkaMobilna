using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int health = 2;
    public Sprite fishNormalSprite;
    public Sprite fishDamagedSprite;

    protected SpriteRenderer FishSpriteRenderer;

    private void Start()
    {
        FishSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Torpedo")
        {
            health -= 1;
            if (health == 0)
                Destroy(gameObject);
            else
            {
                FishSpriteRenderer.sprite = fishDamagedSprite;
                StartCoroutine(RevertSprite(0.1f));
            }
        }
    }

    IEnumerator RevertSprite(float time)
    {
        yield return new WaitForSeconds(time);
        FishSpriteRenderer.sprite = fishNormalSprite;
    }

}
