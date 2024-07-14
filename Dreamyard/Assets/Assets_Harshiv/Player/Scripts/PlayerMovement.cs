using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;

    public float speed = 5;
    public float jump = 20;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;

    private bool isFacingRight;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public float damageCooldown = 1.0f;  // Time in seconds before damage can be taken again
    private float lastDamageTime = -Mathf.Infinity;

    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
        }
        if (Move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isJumping", !isGrounded());

        if (!isFacingRight && Move > 0)
        {
            Flip();
        }
        else if (isFacingRight && Move < 0)
        {
            Flip();
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector" && Time.time > lastDamageTime + damageCooldown)
        {
            health.TakeDamage(1.0f);
            transform.position = respawnPoint;
            lastDamageTime = Time.time;
        }

        else if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
    }

    public bool canAttack()
    {
        return true;
    }
}