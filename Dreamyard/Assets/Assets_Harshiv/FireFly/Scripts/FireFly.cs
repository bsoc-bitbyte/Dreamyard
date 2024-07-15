using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed = 4.0f;
    public float chaseRadius = 5.0f;
    public float straightDistance = 3.0f;
    public float explosionDelay = 5.0f; // Time delay before exploding after starting to chase
    public float damageCooldown = 2.0f; // Cooldown time between damage applications
    private Transform player;
    private Animator animator;
    private bool isExploding = false;
    private bool isChasing = false;
    private bool isGoingStraight = false;
    private Vector3 straightDirection;
    private float chaseStartTime;
    private float lastDamageTime;

    [SerializeField] private AudioClip FlyClip;
    [SerializeField] private float volume;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isExploding)
        {
            return;
        }

        Vector3 direction;

        if (isGoingStraight)
        {
            // Continue in the straight direction
            direction = straightDirection;
        }
        else if (isChasing)
        {
            // Chase the player
            animator.SetTrigger("Chase");
            direction = (player.position - transform.position).normalized;

            // Check if the distance to the player is within the straight distance
            if (Vector3.Distance(player.position, transform.position) <= straightDistance)
            {
                isGoingStraight = true;
                straightDirection = direction;
            }

            // Check if it's time to explode
            if (Time.time - chaseStartTime >= explosionDelay)
            {
                Explode();
            }
        }
        else
        {
            // Check if the player is within the chase radius
            if (Vector3.Distance(player.position, transform.position) <= chaseRadius)
            {
                isChasing = true;
                chaseStartTime = Time.time; // Record the time when chasing starts
            }
            direction = Vector3.zero; // No movement if not chasing
        }

        if (direction != Vector3.zero)
        {
            // Move towards the target direction
            transform.position += direction * speed * Time.deltaTime;

            // Rotate towards the target direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time - lastDamageTime >= damageCooldown)
        {
            // Trigger the explosion
            Explode();

            // Deal damage to the player (assuming player has a health script)
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f); // Call a method in Health to handle damage
                lastDamageTime = Time.time; // Update last damage time
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            // Trigger the explosion if collides with ground
            Explode();
        }
    }

    void Explode()
    {
        isExploding = true;
        SoundManager.instance.PlaySound(FlyClip, volume);
        animator.SetTrigger("Explode");
    }

    // Called by the animation event at the end of the explosion animation
    public void OnExplosionComplete()
    {
        gameObject.SetActive(false);
    }

    // Draw the chase radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
