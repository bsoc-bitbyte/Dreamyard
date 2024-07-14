using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    public Transform player;
    public float sightRange = 5f;
    public float attackRange = 1f;
    public float moveSpeed = 3f;
    public float damage = 1.0f;
    private bool playerInSight;
    private bool isAttacking;

    private WolfPatrol wolfPatrol;
    private Animator animator;

    private Health playerHealth;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("SFX")]
    [SerializeField] private AudioClip AttackSound;
    [SerializeField] private float volume;

    private float cooldownTimer = Mathf.Infinity;

    void Start()
    {
        wolfPatrol = GetComponent<WolfPatrol>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        DetectPlayer();

        if (playerInSight)
        {
            AttackPlayer();
        }
        else
        {
            wolfPatrol.enabled = true;
            animator.SetTrigger("Walking");
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.position.x, 0));
        playerInSight = distanceToPlayer <= sightRange && IsPlayerInPatrolZone();
    }

    void AttackPlayer()
    {
        wolfPatrol.enabled = false;
        animator.SetTrigger("Running");

        if (Mathf.Abs(transform.position.x - player.position.x) > attackRange)
        {
            Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Change direction based on movement
            if (targetPosition.x > transform.position.x)
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            }
            else if (targetPosition.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
            }
        }
        else
        {
            if (!isAttacking && PlayerInSight())
            {
                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0;
                    isAttacking = true;
                    animator.SetTrigger("Attack1");
                    // Reset attacking state after attack duration (e.g., 1 second)
                    Invoke(nameof(ResetAttack), 0.1f);
                    if (AttackSound != null)
                    {
                        SoundManager.instance.PlaySound(AttackSound, volume);
                    }
                }
            }
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    bool IsPlayerInPatrolZone()
    {
        // Check if player is within patrol zone (between the first and last patrol points)
        float leftBound = Mathf.Min(wolfPatrol.patrolPoints[0].position.x, wolfPatrol.patrolPoints[wolfPatrol.patrolPoints.Length - 1].position.x);
        float rightBound = Mathf.Max(wolfPatrol.patrolPoints[0].position.x, wolfPatrol.patrolPoints[wolfPatrol.patrolPoints.Length - 1].position.x);
        return player.position.x >= leftBound && player.position.x <= rightBound;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.collider.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    public void DamagePlayer()
    {

        // Assuming the player has a script with a method TakeDamage(float damage)
        
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
