using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndDestroy : MonoBehaviour
{
    protected Rigidbody2D mineRB;
    protected bool detected = false;

    public float speed = 5f;

    void Start()
    {
        mineRB = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!detected && col.tag == "Player")
        {
            detected = true;
            mineRB.AddForce((col.transform.position - transform.position) * speed);
        }

    }
}
