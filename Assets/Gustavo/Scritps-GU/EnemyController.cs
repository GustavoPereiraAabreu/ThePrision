using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 2;
    private float attackTimer =;

    void Start()
    {
        gameObject.tag = "Enemy";
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && attackTimer <= 0)
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            player.TakeDamage();
            attackTimer = 8f; // Aguarda 1 segundo antes de atacar novamente
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}