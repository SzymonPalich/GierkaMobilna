using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndingMenu;
    private LevelEnding levelEnding;
    private Player player;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        levelEnding = canvas.GetComponent<LevelEnding>();
        player = gameObject.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Hurt")
        {
            player.TakeDamage(100);
            Handheld.Vibrate();
        }
        if (col.tag == "Finish")
        {
            levelEnding.ShowMenu();
        }
    }
}
