using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxOxygen = 100;

    private int CurrentHealth;
    private int CurrentOxygen;

    public float damageMultiplier = 5.0f;
    public float minDamage = 2.0f;

    private Rigidbody2D playerBody;

    public Health health;
    public Oxygen oxygen;

    private float nextActionTime = 0.0f;
    private readonly float period = 1.0f;

    public GameObject UIComponent;
    private GameMenus gameMenus;
    public GameMenus GameMenus { get; }

    private AudioManager audioManager;
    private AudioSource audioSource;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        gameMenus = UIComponent.GetComponent<GameMenus>();

        CurrentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);

        CurrentOxygen = maxOxygen;
        oxygen.SetMaxOxygen(maxOxygen);

        audioManager = GetComponent<AudioManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!gameMenus.IsPaused)
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
            audioSource.PlayOneShot(audioManager.playerDeath);
            gameMenus.ShowGameOver();
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
        int damageDealt = (calculatedDamage > minDamage) ? (int)calculatedDamage : 0;

        TakeDamage(damageDealt);
    }

    public void DrainOxygen()
    {
        if (CurrentOxygen - 1 <= 0)
        {
            CurrentOxygen = 0;
            oxygen.SetOxygen(CurrentOxygen);
            audioSource.PlayOneShot(audioManager.playerDeath);
            gameMenus.ShowGameOver();
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
