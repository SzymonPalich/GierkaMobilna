using UnityEngine;

public class Torpedo : MonoBehaviour
{
    private Rigidbody2D torpedoRB;
    public float Force = 12.0f;
    void Start()
    {
        torpedoRB = GetComponent<Rigidbody2D>();
        torpedoRB.AddRelativeForce(new Vector2(0.0f, Force));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hurt") || col.CompareTag("Enemy") || col.CompareTag("AngryFish"))
        {
            Destroy(gameObject);
        }
    }
}
