using UnityEngine;

public class FindAndDestroy : MonoBehaviour
{
    protected Rigidbody2D mineRB;
    protected bool detected = false;

    public float speed = 64.0f;

    void Start()
    {
        mineRB = transform.parent.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!detected && col.tag == "Player")
        {
            detected = true;
            mineRB.AddForce((col.transform.position - transform.position) * speed);
        }
    }
}
