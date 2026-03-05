using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform boss;
    public float attackRange = 1.5f;
    public KeyCode attackKey = KeyCode.Mouse0;

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (boss == null) return;

        float distance = Vector2.Distance(transform.position, boss.position);

        if (distance <= attackRange)
        {
            BossLife bossLife = boss.GetComponent<BossLife>();

            if (bossLife != null)
            {
                bossLife.TakeDamage();
            }
        }
    }
}