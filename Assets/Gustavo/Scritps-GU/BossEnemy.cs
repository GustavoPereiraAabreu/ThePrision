using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private float tempoEstaticoInicial = 3f;
    private bool podeMover = false;
    [SerializeField] private float timerInicial = 0f;
    private Animator animator;
    private SpriteRenderer _spriteRenderer;


    [Header("Referências")]
    [SerializeField] private Transform player;

    [Header("Movimento")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float stopDistance = 0.5f;

    [Header("Dano por contato")]
    [SerializeField] private float damageCooldown = 1.5f;
    private float damageTimer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!podeMover)
        {
            timerInicial += Time.deltaTime;
            if (timerInicial >= tempoEstaticoInicial)
            {
                podeMover = true;
            }

            animator.SetBool("BossAndando", false);
            return;
        }

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

