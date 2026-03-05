using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackTime = 0.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o que atingimos tem o script de vida
        Health hp = collision.GetComponent<Health>();

        if (hp != null)
        {
            hp.TakeDamage(1); // Tira 1 de vida
        }
    }

    void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    System.Collections.IEnumerator AttackCoroutine()
    {
        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackTime);

        attackHitbox.SetActive(false);
    }
}