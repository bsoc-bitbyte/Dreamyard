using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BossMagicArrow : MonoBehaviour
{
    public float speed = 10f;
    public float explodeTime = 7f;
    private Vector2 target;

    private float damageCooldown = 1f;
    public float damage = 1f;

    private bool canDamage = true;
    private Animator anim;


    private float timer;
    private bool isExploding;
    private Vector3 originalScale;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    public void Initialize(Vector2 target)
    {
        
        target.y += 0.5f;
        this.target = target;
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        }


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
        if (collision.CompareTag("Player") && canDamage)
        {
            canDamage = false;
            StartCoroutine(ResetDamageCooldown());
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


    private IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }

    private void Explode()
    {
        if (!isExploding)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anim.SetTrigger("Explode");
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
        anim.ResetTrigger("Explode");
        isExploding = false;
        timer = 0f;
        canDamage = true;
    }
}
