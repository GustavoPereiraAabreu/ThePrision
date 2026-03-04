using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _spriteRenderer;
    private bool isAttacking = false;

    [Header("Referências")]
    public Transform player;

    [Header("Movimento")]
    public float speed = 3f;
    public float stopDistance = 2f;

    [Header("Vida")]
    public int maxHealth = 50;
    private int currentHealth;

    [Header("Ataque")]
    public float attackCooldown = 2f;
    public int damage = 10;
    private float attackTimer;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (player == null) return;

        attackTimer += Time.deltaTime;

        if (!isAttacking)
        {
            MoveToPlayer();
            HandleAttack();
        }
        else
        {
            if (attackTimer >= attackCooldown)
            {
                isAttacking = false;
            }
        }

        animator.SetBool("BossAndando", Vector2.Distance(transform.position, player.position) > stopDistance);
            if (player.position.x > transform.position.x)
            {
                _spriteRenderer.flipX = true;
            }
            else if (player.position.x < transform.position.x)
            {
                _spriteRenderer.flipX = false;
            }

    }

    void MoveToPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    void HandleAttack()
    {
        attackTimer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);
        

        if (distance <= stopDistance && attackTimer >= attackCooldown)
        {
            Attack();
            attackTimer = 0f;
        }
       
    }

    void Attack()
    {
        isAttacking = true;  
        attackTimer = 0f; 

        animator.SetTrigger("BossAtacando");
        // Aqui você pode chamar o script de vida do player
        // player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Boss tomou dano! Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss derrotado!");
        Destroy(gameObject);
    }
}