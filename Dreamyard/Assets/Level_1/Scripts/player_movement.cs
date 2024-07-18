using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class player_movement : MonoBehaviour
{

    public SpriteRenderer playerColor;
    public Player_update_script playerUpdate;
    public Rigidbody2D player;
    public Sprite_change_script color;
    public GameController gm;
    private bool grounded;
    public float moveSpeed;
    public float jumpSpeed;
    public float newSpeed = 0;
    public float xInput;
    public float yInput;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6;
        jumpSpeed = 6;
        playerColor = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        checkGround();
        CheckInput();
        handleJump();
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }


    void checkGround()
    {
        grounded = gm.grounded;
    }

    void playerMovement()
    {
        if(playerColor.color == color.squareColor[0] && playerUpdate.isInEffect)
        {
            player.velocity = new Vector2(xInput, yInput).normalized * moveSpeed;
            player.gravityScale = 0;
        }
        else
        {
            player.gravityScale = 1;
            if (Mathf.Abs(xInput) > 0)
            {
                newSpeed = moveSpeed * transform.localScale.x;
                player.velocity = new Vector2(newSpeed, player.velocity.y);
            }
            else if (xInput == 0 && grounded)
            {
                newSpeed = 0;
                player.velocity = new Vector2(newSpeed, player.velocity.y);
            }
            else player.velocity = new Vector2(newSpeed, player.velocity.y);
        }
    }

    void handleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            audioManager.PlaySFX(audioManager.jump);
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }

    void flip()
    {
        if (xInput < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (xInput > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }
}
