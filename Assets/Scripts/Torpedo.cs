using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    public Rigidbody2D torpedoRB;
    public float Force = 12.0f;
    void Start()
    {
        torpedoRB = gameObject.GetComponent<Rigidbody2D>();
        torpedoRB.AddRelativeForce(new Vector2(0.0f, Force));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hurt" || col.tag == "Enemy" || col.tag == "AngryFish")
            Destroy(gameObject);
    }
}
