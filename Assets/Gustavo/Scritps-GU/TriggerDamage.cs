using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public int damageAmount = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            BossHealth enemyHealth = collision.gameObject.GetComponent<BossHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}
