using UnityEngine;
using System.Collections;

public class FlyEye : MonoBehaviour
{
    public float moveAwayDistance = 2.0f; // Distance to move away when hurt
    public float moveDuration = 0.5f; // Duration of the move
    public float damageToPlayer = 1.0f; // Damage dealt to the player upon contact
    public float damageCooldown = 1.0f; // Cooldown duration between damages
    public float dropSpeed = 5.0f; // Speed at which the enemy drops to the ground
    public float chaseSpeed = 3.0f; // Speed at which the enemy chases the player
    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb;
    private Collider2D col; // Reference to the Collider2D component
    private bool isMovingAway = false; // Flag to track if the enemy is moving away
    private float lastDamageTime = 0f; // Time when last damage was applied
    private bool isDead = false; // Flag to track if the enemy is dead
    private bool isPlayerInBoundary = false; // Flag to track if the player is in the boundary
    private BoxCollider2D boundaryCollider; // Reference to the boundary collider

    void Start()
    {
        player = GameObject.Find("Player").transform; // Find the player by name
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        col = GetComponent<Collider2D>(); // Get the Collider2D component
        rb.gravityScale = 0f; // Disable gravity initially

        // Find and assign the boundary collider by name
        boundaryCollider = GameObject.Find("FlyEyeBoundary").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Check if the FlyEye is outside the boundary and clamp its position
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, boundaryCollider.bounds.min.y, boundaryCollider.bounds.max.y);
        transform.position = clampedPosition;

        // Chase the player if the player is in the boundary and the FlyEye is not dead
        if (isPlayerInBoundary && !isDead && rb != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * chaseSpeed;
            FlipTowardsPlayer();
        }
    }

    // Method to flip the FlyEye towards the player
    private void FlipTowardsPlayer()
    {
        Vector3 scale = transform.localScale;
        if ((player.position.x < transform.position.x && scale.x > 0) || (player.position.x > transform.position.x && scale.x < 0))
        {
            scale.x *= -1; // Flip the x scale to face the player
        }
        transform.localScale = scale;
    }

    // Method to be called by the animation event
    public void MoveAwayFromPlayer()
    {
        if (!isMovingAway && !isDead)
        {
            // Start the coroutine to move away smoothly
            StartCoroutine(SmoothMoveAwayFromPlayer());
        }
    }

    private IEnumerator SmoothMoveAwayFromPlayer()
    {
        isMovingAway = true;

        // Calculate direction away from the player
        Vector2 directionAwayFromPlayer = (transform.position - player.position).normalized;

        // Calculate the target position
        Vector2 targetPosition = (Vector2)transform.position + directionAwayFromPlayer * moveAwayDistance;

        // Get the starting position
        Vector2 startingPosition = transform.position;

        float elapsedTime = 0f;

        // Smoothly move towards the target position
        while (elapsedTime < moveDuration)
        {
            if (rb != null)
            {
                rb.MovePosition(Vector2.Lerp(startingPosition, targetPosition, elapsedTime / moveDuration));
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        if (rb != null)
        {
            rb.MovePosition(targetPosition);
        }
        isMovingAway = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ApplyDamage(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ApplyDamage(collision.gameObject);
        }
    }

    private void ApplyDamage(GameObject player)
    {
        // Check if enough time has passed since the last damage
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            // Get the player's health script and apply damage
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
                lastDamageTime = Time.time; // Update the time when damage was last applied
            }
        }
    }

    public void Die()
    {
        isDead = true;
        // Disable collision with the player
        col.isTrigger = true;
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Stop any velocity
            rb.gravityScale = 0f; // Disable gravity to prevent falling further
        }
        // Add any other logic needed when the enemy dies
    }

    // Method to be called by the animation event to drop the enemy
    public void DropToGround()
    {
        if (isDead && rb != null)
        {
            rb.gravityScale = 1.0f; // Enable gravity to drop the enemy
            rb.velocity = new Vector2(0, -dropSpeed); // Set the drop speed
        }
    }

    public void SetPlayerInBoundary(bool isInBoundary)
    {
        isPlayerInBoundary = isInBoundary;
        if (!isInBoundary && rb != null)
        {
            rb.velocity = Vector2.zero; // Stop movement when player exits the boundary
        }
    }
}
