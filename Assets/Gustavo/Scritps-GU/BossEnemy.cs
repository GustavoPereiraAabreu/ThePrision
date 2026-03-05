using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _spriteRenderer;

    [Header("Referências")]
    public Transform player;

    [Header("Movimento")]
    public float speed = 3f;
    public float stopDistance = 0.5f;

    [Header("Dano por contato")]
    public float damageCooldown = 1.5f;
    private float damageTimer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        damageTimer += Time.deltaTime;

        MoveToPlayer();

        animator.SetBool("BossAndando",
            Vector2.Distance(transform.position, player.position) > stopDistance);

        if (player.position.x < transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }

        if (Vector2.Distance(transform.position, player.position) <= stopDistance)
        {
            animator.SetTrigger("BossAtacando");
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageTimer >= damageCooldown)
            {
                PlayerLife playerLife = collision.gameObject.GetComponent<PlayerLife>();

                if (playerLife != null)
                {
                    playerLife.TakeDamage();
                }

                damageTimer = 1f;
            }
        }
    }
   
}

