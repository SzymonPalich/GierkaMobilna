using System.Collections;
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
            mineRB.AddForce((col.transform.position - transform.position) * speed);
            StartCoroutine(DetectionCooldown());
            StartCoroutine(Stop());
        }
    }

    IEnumerator DetectionCooldown()
    {
        detected = true;
        yield return new WaitForSeconds(2.0f);
        detected = false;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1.0f);
        mineRB.velocity = new Vector2(0.0f, 0.0f);
    }


}
