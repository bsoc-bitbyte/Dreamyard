using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float timeBtwDamage = 1.5f;

    private Animator anim;

    public Transform player;

    private float moveDistance = 4f; // Adjust the distance the boss should move away
    private float moveDuration = 0.5f; // Duration of the movement

    public float leftBoundary; // Left boundary limit
    public float rightBoundary; // Right boundary limit
    public Vector3 centerPosition;

    public ParticleSystem deathParticles; // Particle system for death effect

    private BossSphereHolder bossSphereHolder;
    private BossArrowHolder bossArrowHolder;

    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        bossSphereHolder = GameObject.FindObjectOfType<BossSphereHolder>();
        bossArrowHolder = GameObject.FindObjectOfType<BossArrowHolder>();
    }

    private void Update()
    {   
        
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
    }
    

    public void FireArrow()
    {
        bossArrowHolder.ShootMagicArrow();
    }



    public void FireSphere()
    {
        bossSphereHolder.ShootMagicSphere();
    }

    public void MoveAwayFromPlayer()
    {
        StartCoroutine(MoveAway());
    }

    private IEnumerator MoveAway()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;

        if (startPosition.x < player.position.x)
        {
            targetPosition.x -= moveDistance;
        }
        else
        {
            targetPosition.x += moveDistance;
        }

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // Check boundaries after moving
        if (transform.position.x < leftBoundary || transform.position.x > rightBoundary)
        {
            // Teleport to the center
            transform.position = centerPosition;
        }
    }

    public void OnDeathAnimationEnd()
    {
       
        ParticleSystem particles = Instantiate(deathParticles, transform.position, Quaternion.identity);

        StartCoroutine(MoveParticlesTowardsPlayer(particles));

        StartCoroutine(HandleDeath());

    }

    private IEnumerator MoveParticlesTowardsPlayer(ParticleSystem particles)
    {
        // Wait a short delay before particles start moving (if desired)
        yield return new WaitForSeconds(0.5f);

        // Calculate direction from boss to player
        Vector3 direction = (player.position - transform.position).normalized;

        // Get particle system's main module
        ParticleSystem.MainModule mainModule = particles.main;

        // Set velocity over lifetime to move particles towards player
        mainModule.startLifetime = 5f; // Example: Adjust particle lifetime as needed
        mainModule.startSpeed = 10f; // Example: Adjust particle speed as needed

        // Simulate particle movement towards player
        particles.transform.LookAt(player); // Orient particles towards player

        // You may adjust other settings like gravity, rotation, etc. here as needed

        // Play particle system
        particles.Play();
    }

    private IEnumerator HandleDeath()
    {
        // Delay for 5 seconds
        yield return new WaitForSeconds(14f);

        // Teleport player to next scene
        GameManager.Instance.TeleportPlayerToNextScene();
    }
}
