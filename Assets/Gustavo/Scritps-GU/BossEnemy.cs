using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _spriteRenderer;

    [Header("Referências")]
    public Transform player;

    [Header("Movimento")]
    public float speed = 3f;
    public float stopDistance = 2f;


    [Header("Ataque")]
    public float attackCooldown = 2f;
    public int damage = 10;
    private float attackTimer;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (player == null) return;

        attackTimer += Time.deltaTime;

            MoveToPlayer();
            HandleAttack();
        
     
            animator.SetBool("BossAndando", Vector2.Distance(transform.position, player.position) > stopDistance);

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
        attackTimer = 0f; 

        animator.SetTrigger("BossAtacando");
        
    }

}