using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int CurrentHealth;
    public int maxOxygen = 100;
    private int CurrentOxygen;

    public float damageMultiplier = 4.0f;
    public float minDamage = 2.0f;
    private Rigidbody2D playerBody;

    public Health health;
    public Oxygen oxygen;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    public GameObject levelEndingComponent;
    private LevelEnding levelEnding;

    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        levelEnding = levelEndingComponent.GetComponent<LevelEnding>();

        CurrentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);

        CurrentOxygen = maxOxygen;
        oxygen.SetMaxOxygen(maxOxygen);
    }

    private void Update()
    {
        if (!levelEnding.GameOverCheck)
        {
            if (Time.timeSinceLevelLoad > nextActionTime)
            {
                nextActionTime += period;
                DrainOxygen();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth - damage <= 0)
        {
            CurrentHealth = 0;
            health.SetHealth(CurrentHealth);
            levelEnding.setGameOver();
            levelEnding.ShowMenu();
        }
        else
        {
            CurrentHealth -= damage;
            health.SetHealth(CurrentHealth);
        }
    }


    public void TakeDamageCollison()
    {
        float calculatedDamage = (Abs(playerBody.velocity.x) + Abs(playerBody.velocity.y)) * damageMultiplier;
        int damageDealt = (calculatedDamage > minDamage) ? (int) calculatedDamage : 0;

        TakeDamage(damageDealt);
    }

    public void DrainOxygen()
    {
        if (CurrentOxygen - 1 <= 0)
        {
            CurrentOxygen = 1;
            oxygen.SetOxygen(CurrentOxygen);
            levelEnding.setGameOver();
            levelEnding.ShowMenu();

        }
        else
        {
            CurrentOxygen -= 1;
            oxygen.SetOxygen(CurrentOxygen);
        }
    }

    protected float Abs(float value)
    {
        return (value > 0) ? value : -value;
    }
}
