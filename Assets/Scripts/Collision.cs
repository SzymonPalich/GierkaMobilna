using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hurt")
        {
            Debug.Log("OnTriggerEnter2D");
        }
        if (col.tag == "Finish")
        {
            Debug.Log("Finish");
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
