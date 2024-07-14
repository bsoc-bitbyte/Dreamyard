using System.Linq;
using UnityEngine;

public class PlayerMagicPillar : MonoBehaviour
{
    public GameObject magicPillarPrefab;
    public float magicPillarCooldown = 5f;
    public float spawnYOffset = 1f; // Offset to move the pillar up on the Y-axis
    private float nextMagicPillarTime = 0f;

    private GameObject magicPillarInstance;
    private Animator anim;

    [SerializeField] private AudioClip MagicPillarClip;
    [SerializeField] private float volume;

    void Start()
    {
        // Create an instance of the magic pillar and disable it initially
        magicPillarInstance = Instantiate(magicPillarPrefab, Vector2.zero, Quaternion.identity);
        magicPillarInstance.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.time >= nextMagicPillarTime)
        {
            SoundManager.instance.PlaySound(MagicPillarClip, volume);
            anim.SetTrigger("MagicPillar");
            nextMagicPillarTime = Time.time + magicPillarCooldown;
        }
    }

    void ActivateMagicPillar()
    {
        GameObject enemy = FindClosestEnemy();

        if (enemy != null)
        {
            // Set the magic pillar position with an offset on the Y-axis
            Vector2 spawnPosition = new Vector2(enemy.transform.position.x, enemy.transform.position.y + spawnYOffset);
            magicPillarInstance.transform.position = spawnPosition;
            magicPillarInstance.transform.rotation = Quaternion.identity;
            magicPillarInstance.SetActive(true);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");

        GameObject[] allEnemies = enemies.Concat(heroes).ToArray();

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        foreach (GameObject enemy in allEnemies)
        {
            // Check if the enemy has a collider and if it's enabled
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
            if (enemyCollider != null && !enemyCollider.enabled)
            {
                continue; // Skip enemies with disabled colliders
            }

            float distance = Vector2.Distance(currentPosition, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

}
