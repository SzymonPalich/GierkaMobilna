using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    private int CurrentHealth;
    public int maxOxygen;
    private int CurrentOxygen;

    public Health health;
    public Oxygen oxygen;

    void Start()
    {
        CurrentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);

        CurrentOxygen = maxOxygen;
        oxygen.SetMaxOxygen(maxOxygen);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        health.SetHealth(CurrentHealth);
    }

    private void Update()
    {
        TakeDamage(1);
    }
}
