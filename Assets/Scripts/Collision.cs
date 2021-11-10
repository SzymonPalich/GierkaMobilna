using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndingMenu;
    private LevelEnding levelEnding;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        levelEnding = canvas.GetComponent<LevelEnding>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hurt")
        {
            Handheld.Vibrate();
        }
        if (col.tag == "Finish")
        {
            levelEnding.ShowMenu();
        }
    }
}
