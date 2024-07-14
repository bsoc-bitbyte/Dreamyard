using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Movement Parameters")]
    [SerializeField] private float moveSpeed;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("SFX")]
    [SerializeField] private AudioClip HeroAttack;
    [SerializeField] private float volume;

    [Header("Move Away")]
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveDuration = 1f;

    private float cooldownTimer = Mathf.Infinity;
    private bool isAttacking = false;
    private bool isMovingAway = false;

    private Animator anim;
    private Health playerHealth;
    private Transform playerTransform;
    private HeroicDialogue dialogue; // Reference to the HeroicDialogue script

    private AudioSource attackSoundSource; // Separate AudioSource for attack sounds

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;

        // Create a new AudioSource component for attack sounds
        attackSoundSource = gameObject.AddComponent<AudioSource>();

        // Get the HeroicDialogue component
        dialogue = GetComponent<HeroicDialogue>();
    }

    private void Start()
    {
        if (dialogue != null)
        {
            dialogue.StartDialogue(); // Start the dialogue
        }
    }

    private void Update()
    {
        // Check if the dialogue is finished before updating hero behavior
        if (dialogue != null && !dialogue.IsDialogueFinished)
        {
            return;
        }

        if (!isAttacking && !isMovingAway)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= attackCooldown && PlayerInSight())
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
                isAttacking = true;
                if (HeroAttack != null)
                {
                    SoundManager.instance.PlayAttackSound(HeroAttack, volume);
                }
            }
            else
            {
                ChasePlayer();
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.collider.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && playerHealth.GetCurrentHealth() > 0 && playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void ChasePlayer()
    {
        if (playerTransform != null)
        {
            anim.SetTrigger("Run");
            Vector3 targetPosition;
            Vector3 currentPosition = transform.position;

            if (playerTransform.position.x < currentPosition.x)
            {
                targetPosition = new Vector3(playerTransform.position.x + 0.7f, currentPosition.y, currentPosition.z);
                transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            }
            else
            {
                targetPosition = new Vector3(playerTransform.position.x - 0.7f, currentPosition.y, currentPosition.z);
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void FinishAttack()
    {
        isAttacking = false;
    }

    public void MoveAwayFromPlayer()
    {
        if (!isMovingAway)
        {
            StartCoroutine(MoveAway());
        }
    }

    private IEnumerator MoveAway()
    {
        isMovingAway = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;

        if (startPosition.x < playerTransform.position.x)
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
        isMovingAway = false;
        isAttacking = false;
    }

    public void StopAttackSound()
    {
        if (HeroAttack != null)
        {
            SoundManager.instance.StopSound(HeroAttack);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
