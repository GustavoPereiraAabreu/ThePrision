using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossHealth boss = collision.GetComponent<BossHealth>();

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}
