using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public Transform center; // The center point of the circular path
    public float radius = 5f; // The radius of the circle
    public float angularSpeed = 2f; // The angular speed (radians per second)
    public float startingAngle = 0f; // The starting angle

    private float angle;

    [SerializeField] private float damage;

    private float damageCooldown = 1.0f;
    private float lastDamageTime = -Mathf.Infinity;

    [SerializeField] private AudioClip FireSound;

    public float maxDistance = 10f;
    public float minVolume = 0f;
    public float maxVolume = 0.2f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Initialize the angle to the starting angle
        angle = startingAngle;
        if (SoundManager2.instance != null)
        {
            SoundManager2.instance.PlayLoopingSound(FireSound, audioSource, maxDistance, minVolume, maxVolume);
        }
    }

    void Update()
    {
        SoundManager2.instance.UpdateVolumeBasedOnDistance(maxDistance, minVolume, maxVolume);
        // Calculate the new position of the fireball
        angle += angularSpeed * Time.deltaTime; // Increment the angle
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Update the fireball's position
        transform.position = new Vector2(center.position.x + x, center.position.y + y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Time.time > lastDamageTime + damageCooldown)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}
