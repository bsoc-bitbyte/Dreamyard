using UnityEngine;

public class BossSphereHolder : MonoBehaviour
{
    public GameObject[] bossSpheres; // Array to hold the ten pre-created projectiles
    public Transform shootPoint;

    public float damageCooldown = 0.5f; // Time between each damage application
    private Transform player;

    private float lastDamageTime;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        lastDamageTime = -damageCooldown;
    }



    public void ShootMagicSphere()
    {
        
        GameObject sphereMagicProjectile = GetInactiveProjectile();
        if (sphereMagicProjectile != null)
        {
            sphereMagicProjectile.transform.position = shootPoint.position;
            sphereMagicProjectile.SetActive(true);
            sphereMagicProjectile.GetComponent<BES>().Initialize(player.position);

        }
    }

    GameObject GetInactiveProjectile()
    {
        foreach (GameObject projectile in bossSpheres)
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
