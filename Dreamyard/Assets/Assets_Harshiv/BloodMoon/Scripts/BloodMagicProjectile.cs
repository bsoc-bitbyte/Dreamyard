using UnityEngine;

public class BloodMagicProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float explodeTime = 10f;
    public float damage = 10f; // Adjust damage amount as needed
    private Vector2 target;
    private Animator animator;
    private float timer;
    private bool isExploding;
    private Vector3 originalScale;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    public void Initialize(Vector2 target)
    {
        this.target = target;
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localScale = originalScale;

        timer = 0f;
        isExploding = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= explodeTime && !isExploding)
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isExploding) // Check if not exploding to prevent damage during explosion
        {
            if (collision.CompareTag("Player"))
            {
                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    Explode();
                }
            }
            else if (collision.CompareTag("Ground"))
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        if (!isExploding)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetTrigger("Explode");
            isExploding = true;
        }
    }

    // Called by an Animation Event at the end of the explosion animation
    private void OnExplosionComplete()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Reset projectile for reuse
        animator.ResetTrigger("Explode");
        isExploding = false;
        timer = 0f;
    }
}
