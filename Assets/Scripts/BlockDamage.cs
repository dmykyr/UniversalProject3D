using UnityEngine;

public class BlockDamage : MonoBehaviour
{
    public enum DamageType 
    {
        Spike,
        Blade
    }

    public float damageCooldown = 2f;
    public DamageType damageType;

    private float lastDamageTime;
    private bool canTakeDamage = true;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTakeDamage)
        {
            if(gameManager != null)
            {
                gameManager.HealthAmount -= ((int)damageType + 1) * 20;

                lastDamageTime = Time.time;
                canTakeDamage = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.HealthAmount -= ((int)damageType + 1) * 20;

                lastDamageTime = Time.time;
                canTakeDamage = false;
            }
        }
    }

    private void Update()
    {
        if (!canTakeDamage && Time.time - lastDamageTime >= damageCooldown)
        {
            canTakeDamage = true;
        }
    }
}
