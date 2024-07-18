using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer playerColor;
    public Collider2D groundCheck;
    public bool grounded;
    public bool notDead;
    public LayerMask layerMask;
    [SerializeField]
    player_movement playerScript;
    public Player_update_script playerUpdate;
    public Vector2 checkPointPos;
    public Transform startPos;

    public ParticleSystem particle;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        checkPointPos = transform.localPosition;
        startPos = transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        checkGround();
        if (grounded && notDead) playerScript.enabled = true;
    }

    void checkGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, layerMask).Length > 0.1f;
    }

    

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }

    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.velocity = Vector2.zero;
        playerScript.newSpeed = 0;
        playerScript.enabled = false;
        notDead = false;
        transform.localScale = new Vector3(0, 0, 0);
        Instantiate(particle, transform.position, Quaternion.identity);
        audioManager.PlaySFX(audioManager.death);
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        transform.localScale = new Vector3(1, 1, 1);
        notDead = true;
        playerColor.color = playerUpdate.defaultColor;
        rb.gravityScale = 1;

        playerUpdate.boostTimer = 0;
        playerUpdate.boostTimerG = 0;
        playerUpdate.boostTimerB = 0;
        playerUpdate.boostTimerR = 0;
        playerUpdate.boostTimerY = 0;
    }
}
