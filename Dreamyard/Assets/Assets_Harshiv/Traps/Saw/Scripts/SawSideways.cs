using System.Collections;
using UnityEngine;

public class SawSideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage = 0.5f;
    [SerializeField] private float damageCooldown = 1.0f;  // Cooldown period in seconds

    [SerializeField] private AudioClip SawSound;


    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private bool canDamage = true;// Can the saw damage the player


    public float maxDistance = 10f;
    public float minVolume = 0f;
    public float maxVolume = 0.2f;

    private AudioSource audioSource;

    private void Awake()
    {
        float startingX = transform.position.x;  // Use the current position's x value as the starting point
        leftEdge = startingX - movementDistance;
        rightEdge = startingX + movementDistance;

        audioSource = GetComponent<AudioSource>();

    }
    private void Start()
    {
        if (SoundManager2.instance != null)
        {
            SoundManager2.instance.PlayLoopingSound(SawSound, audioSource, maxDistance, minVolume, maxVolume);
        }
    }

    private void Update()
    {
        SoundManager2.instance.UpdateVolumeBasedOnDistance(maxDistance, minVolume, maxVolume);
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canDamage)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
