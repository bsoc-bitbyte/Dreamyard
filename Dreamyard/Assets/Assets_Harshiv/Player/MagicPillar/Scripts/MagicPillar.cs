using UnityEngine;

public class MagicPillar : MonoBehaviour
{
    public float damage = 10f;
    public float activeDuration = 2f;

    private void OnEnable()
    {
        Invoke("Deactivate", activeDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Hero"))
        {
            // Deal damage to the enemy
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
