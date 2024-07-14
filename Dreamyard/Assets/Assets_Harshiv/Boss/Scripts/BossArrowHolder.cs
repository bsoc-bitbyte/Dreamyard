using UnityEngine;

public class BossArrowHolder : MonoBehaviour
{
    public GameObject[] bossArrows; // Array to hold the ten pre-created projectiles
    public Transform shootPoint;

    public float damageCooldown = 0.5f; // Time between each damage application
    private Transform player;

    private float lastDamageTime;


    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        lastDamageTime = -damageCooldown;
    }



    public void ShootMagicArrow()
    {
        
        GameObject arrowMagicProjectile = GetInactiveProjectile();
        if (arrowMagicProjectile != null)
        {
            arrowMagicProjectile.transform.position = shootPoint.position;
            arrowMagicProjectile.SetActive(true);
            arrowMagicProjectile.GetComponent<BossMagicArrow>().Initialize(player.position);

        }
    }

    GameObject GetInactiveProjectile()
    {
        foreach (GameObject projectile in bossArrows)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }
        return null;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= lastDamageTime + damageCooldown)
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1f); // Ensure to always apply 1 damage
                lastDamageTime = Time.time;
            }
        }
    }
}
