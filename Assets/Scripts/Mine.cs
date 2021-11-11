using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int health = 3;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Torpedo")
        {
            health -= 1;
            if (health == 0)
                Destroy(transform.parent.gameObject);
        }
    }
}
