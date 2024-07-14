using UnityEngine;

public class BloodMagicShooter : MonoBehaviour
{
    public GameObject[] bloodMagicProjectiles; // Array to hold the ten pre-created projectiles
    public Transform shootPoint;
    public float detectionRadius = 5f;
    public float cooldownTime = 2f;
    public float damageCooldown = 1f; // Time between each damage application
    private Transform player;
    private float lastShootTime;
    private float lastDamageTime;

    [SerializeField] private AudioClip BloodMagicClip;
    [SerializeField] private float volume;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastShootTime = -cooldownTime;
        lastDamageTime = -damageCooldown;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            if (Time.time >= lastShootTime + cooldownTime)
            {
                ShootBloodMagic();
                lastShootTime = Time.time;
            }
        }
    }

    void ShootBloodMagic()
    {
        SoundManager.instance.PlaySound(BloodMagicClip, volume);
        GameObject bloodMagicProjectile = GetInactiveProjectile();
        if (bloodMagicProjectile != null)
        {
            bloodMagicProjectile.transform.position = shootPoint.position;
            bloodMagicProjectile.SetActive(true);
            bloodMagicProjectile.GetComponent<BloodMagicProjectile>().Initialize(player.position);
        }
    }

    GameObject GetInactiveProjectile()
    {
        foreach (GameObject projectile in bloodMagicProjectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }
        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
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
