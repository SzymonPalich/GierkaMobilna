using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int health = 3;
    public Sprite mineNormalSprite;
    public Sprite mineDamagedSprite;

    protected SpriteRenderer MineSpriteRenderer;

    private void Start()
    {
        MineSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Torpedo")
        {
            health -= 1;
            if (health == 0)
                Destroy(transform.parent.gameObject);
            else
            {
                MineSpriteRenderer.sprite = mineDamagedSprite;
                StartCoroutine(RevertSprite(0.1f));
            }
        }
    }

    IEnumerator RevertSprite(float time)
    {
        yield return new WaitForSeconds(time);
        MineSpriteRenderer.sprite = mineNormalSprite;
    }
}
