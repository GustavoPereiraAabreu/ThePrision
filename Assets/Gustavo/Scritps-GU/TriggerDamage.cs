using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        BossHealth boss = collision.GetComponent<BossHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}
